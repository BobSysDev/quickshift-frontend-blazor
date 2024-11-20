namespace QuickShiftUI.Components.Auth;

using System.Security.Claims;
using System.Text.Json;
using DTOs;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.JSInterop;


public class SimpleAuthProvider : AuthenticationStateProvider
{
    private readonly HttpClient httpClient;
    private readonly IJSRuntime jsRuntime;

    public SimpleAuthProvider(HttpClient httpClient, IJSRuntime jsRuntime)
    {
        this.httpClient = httpClient;
        this.jsRuntime = jsRuntime;
    }
    
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        string userAsJson = "";
        try
        {
            userAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
        }
        catch (InvalidOperationException e)
        {
            return new AuthenticationState(new());
        }

        if (string.IsNullOrEmpty(userAsJson))
        {
            return new AuthenticationState(new());
        }

        PublicEmployeeDTO  employeeDto= JsonSerializer.Deserialize<PublicEmployeeDTO>(userAsJson)!;
        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, employeeDto.FirstName),
            new Claim(ClaimTypes.NameIdentifier, employeeDto.WorkingNumber.ToString())
        };
        ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth");
        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
        
        return new AuthenticationState(claimsPrincipal);
    }

    public async Task Login(int workingNumber, string password)
    {
        HttpResponseMessage response =
            await httpClient.PostAsJsonAsync("/Auth/authenticate", new AuthEmployeeDTO(){Password = password, WorkingNumber = workingNumber});
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        PublicEmployeeDTO? publicEmployeeDto = JsonSerializer.Deserialize<PublicEmployeeDTO>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        if (publicEmployeeDto is null)
        {
            throw new Exception("DTO returned was null");
        }

        string serializedData = JsonSerializer.Serialize(publicEmployeeDto);
        await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serializedData);

        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, publicEmployeeDto.FirstName),
            new Claim(ClaimTypes.NameIdentifier, publicEmployeeDto.WorkingNumber.ToString())
        };
        
        ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth");
        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    }

    public async Task Logout()
    {
        await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new())));
    }
}
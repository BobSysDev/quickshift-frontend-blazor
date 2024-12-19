using Blazorise.States;

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
        catch (InvalidOperationException)
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        if (string.IsNullOrEmpty(userAsJson))
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        SimpleEmployeeDTO employeeDto = JsonSerializer.Deserialize<SimpleEmployeeDTO>(userAsJson)!;

        int role = (int) AccountRoles.Employee;

        if (employeeDto.IsManager)
        {
            role = (int) AccountRoles.Manager;
        }
        
        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, employeeDto.FirstName),
            new Claim(ClaimTypes.Surname, employeeDto.LastName),
            new Claim(ClaimTypes.NameIdentifier, employeeDto.WorkingNumber.ToString()),
            new Claim(ClaimTypes.Role, role.ToString()),
            new Claim("EmployeeId", employeeDto.Id.ToString())
        };
        ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth");
        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

        return new AuthenticationState(claimsPrincipal);
    }

    public async Task Register(string firstName, string lastName, int workingNumber, string email, string password, bool isManager)
    {
        var newEmployee = new NewEmployeeDTO
        {
            FirstName = firstName,
            LastName = lastName,
            WorkingNumber = workingNumber,
            Email = email,
            Password = password,
            IsManager = isManager
        };

        HttpResponseMessage response = await httpClient.PostAsJsonAsync("/Auth/register", newEmployee);
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        SimpleEmployeeDTO? simpleEmployeeDto = JsonSerializer.Deserialize<SimpleEmployeeDTO>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        if (simpleEmployeeDto is null)
        {
            throw new Exception("DTO returned was null");
        }

        string serializedData = JsonSerializer.Serialize(simpleEmployeeDto);
        await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serializedData);

        int role = (int) AccountRoles.Employee;

        if (simpleEmployeeDto.IsManager)
        {
            role = (int) AccountRoles.Manager;
        }
        
        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, simpleEmployeeDto.FirstName),
            new Claim(ClaimTypes.NameIdentifier, simpleEmployeeDto.WorkingNumber.ToString()),
            new Claim(ClaimTypes.Surname, simpleEmployeeDto.LastName),
            new Claim(ClaimTypes.Role, role.ToString()),
            new Claim("EmployeeId", simpleEmployeeDto.Id.ToString())
        };

        ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth");
        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    }
    
    public async Task<string> RegisterSomeoneElse(string firstName, string lastName, int workingNumber, string email, string password, bool isManager)
    {
        var newEmployee = new NewEmployeeDTO
        {
            FirstName = firstName,
            LastName = lastName,
            WorkingNumber = workingNumber,
            Email = email,
            Password = password,
            IsManager = isManager
        };

        HttpResponseMessage response = await httpClient.PostAsJsonAsync("/Auth/register", newEmployee);
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        return "Account created successfully";
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
        
        Console.WriteLine("Printing the content: "+content);
        
        SimpleEmployeeDTO? simpleEmployeeDto = JsonSerializer.Deserialize<SimpleEmployeeDTO>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        if (simpleEmployeeDto is null)
        {
            throw new Exception("DTO returned was null");
        }

        string serializedData = JsonSerializer.Serialize(simpleEmployeeDto);
        await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serializedData);

        int role = (int) AccountRoles.Employee;

        if (simpleEmployeeDto.IsManager)
        {
            role = (int) AccountRoles.Manager;
        }
        
        Console.WriteLine("SimpleAuth is setting the role to:"+ role);
        
        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, simpleEmployeeDto.FirstName),
            new Claim(ClaimTypes.NameIdentifier, simpleEmployeeDto.WorkingNumber.ToString()),
            new Claim(ClaimTypes.Surname, simpleEmployeeDto.LastName),
            new Claim(ClaimTypes.Role, role.ToString()),
            new Claim("EmployeeId", simpleEmployeeDto.Id.ToString())
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
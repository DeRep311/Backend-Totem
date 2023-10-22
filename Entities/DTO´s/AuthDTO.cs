using Core.entities;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

public class AuthDTO : IDTO
{
    public int cedula {get; set;}
    public int pin {get; set;}
    
}
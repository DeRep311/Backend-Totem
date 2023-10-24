using Core.entities;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
namespace DataAccess.DTOs;

public class AuthDTO :IDTO
{
    public int Cedula {get; set;}
    public int Pin {get; set;}

    
}
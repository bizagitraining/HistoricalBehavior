using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IdentityModel.Selectors;
using System.ServiceModel;

/// <summary>
/// Summary description for UserNamePassValidator
/// </summary>
public class UserNamePassValidator : UserNamePasswordValidator
{
    public override void Validate(string userName, string password)
    {
        if (userName == null || password == null)
        {
            throw new ArgumentNullException();
        }

        if (!(userName == "student" && password == "Bizagi2021"))
        {
            throw new FaultException("Incorrect Username or Password");
        }
    }
}
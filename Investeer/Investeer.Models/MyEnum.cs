using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace Investeer.Models
{
    public static class MyEnum
    {
        public  enum Roles
        {
            SuperAdmin,
            Admin,
            Customer
        }
        public enum DC
        {
            A,
            B,
            C,
            D,
            E,
            F,
            G,
            H,
            I,
            J,
            K,
            L,
            M,
            N,
            O,
            P,
            Q,
            R,
            S,
            T,
            U,
            V,
            W,
            X,
            Y,
            Z,
            AA,
            AB,
            AC,
            AD,
            AE,
            AF,
            AG,
            AH,
            AI,
            AJ,
            AK,
            AL,
            AM,
            AN,
            AO,
            AP,
            SheetName
        }

        public enum EmailTemplates
        {
            [EnumMember(Value = "Invest.html")]
            Invest,
            [EnumMember(Value = "InvestAdmin.html")]
            InvestAdmin,
            [EnumMember(Value = "Contact.html")]
            Contact,
            [EnumMember(Value = "ContactAdmin.html")]
            ContactAdmin,
            [EnumMember(Value = "ConfirmEmail.html")]
            ConfirmEmail,
            [EnumMember(Value = "ResetPassword.html")]
            ResetPassword,
        }

        public static String GetEnumMemberValue<T>(this T value) where T : struct, IConvertible
        {
            return typeof(T)
                .GetTypeInfo()
                .DeclaredMembers
                .SingleOrDefault(x => x.Name == value.ToString())
                ?.GetCustomAttribute<EnumMemberAttribute>(false)
                ?.Value;
        }

    }
}

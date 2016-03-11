using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Statics
{
    public static class SingleFieldValidation
    {
        public static FileData DoesNotContainANumber(this FileData data)
        {
            Logger.Current.Log($"Test:DoesNotContainANumber");
            if (new Regex(@"\d").IsMatch(data.StringValue))
            {
                Logger.Current.Log("Failed:DoesNotContainANumber");
                throw new ArgumentException(data.Fieldname);
            }
            else
                return data;
        }

        public static FileData IsNotNull(this FileData data)
        {
            Logger.Current.Log("Test:IsNotNull");
            if (data.StringValue == null)
            {
                Logger.Current.Log("Failed:IsNotNull");
                throw new ArgumentException(data.Fieldname);
            }
            else
                return data;
        }

        public static FileData IsNotEmpty(this FileData data)
        {
            Logger.Current.Log("Test:IsNotEmpty");
            if (string.IsNullOrWhiteSpace(data.StringValue))
            {
                Logger.Current.Log("Failed:IsNotEmpty");
                throw new ArgumentException(data.Fieldname);
            }
            else
                return data;
        }

        public static FileData IsNoLongerThan256(this FileData data)
        {
            if (data.StringValue.Length > 256)
                throw new ArgumentException(data.Fieldname);
            else
                return data;
        }

        public static FileData IsValidEmployeeNumber(this FileData data)
        {
            if (new Regex(@"^([a-zA-Z]){3}(\d){8}$").IsMatch(data.StringValue))
                return data;
            else
                throw new ArgumentException(data.Fieldname);
        }
    }
}

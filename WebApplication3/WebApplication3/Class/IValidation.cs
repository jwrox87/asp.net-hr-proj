using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication3
{
    // interface for setting validation state
    public interface IValidation
    {
        void SetValidations(bool b);
    }
}

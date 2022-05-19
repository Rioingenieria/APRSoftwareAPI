//using FluentValidation.Results;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common
{
    public class ValidationsFluent
    {
        public ValidationResult Validation { get; set; }
        public Enum.Status.StatusEnum Status { get; set; }
        private string _message;
        public string Message
        {
            get
            {
                switch (Status)
                {
                    case Enum.Status.StatusEnum.Error:
                        _message = "Error al realizar la operación.Por favor comuníquese con el soporte técnico.";
                        break;
                    default:
                        break;
                }
                return _message;
            }
            set
            {
                _message = value;
            }
        }
    }
}

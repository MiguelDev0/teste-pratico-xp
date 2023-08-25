namespace XP.Business.Exception
{
    public class ErrorResponse
    {
        public ErrorResponse()
        {
            Errors = new List<ErrorDetailsDTO>();
        }

        public ErrorResponse(string codigo, string message)
        {
            Errors = new List<ErrorDetailsDTO>();
            AddError(codigo, message);
        }

        public List<ErrorDetailsDTO> Errors { get; private set; }

        public class ErrorDetailsDTO
        {
            public ErrorDetailsDTO(string codigo, string message)
            {
                this.codigo = codigo;
                Message = message;
            }

            public string codigo { get; private set; }

            public string Message { get; private set; }
        }

        public void AddError(string codigo, string message)
        {
            Errors.Add(new ErrorDetailsDTO(codigo, message));
        }
    }
}

using System.Text;

namespace AdaTech.Application
{
    public class Response<T>
    {
        public static Response<T> GenericError = new(new string[] { "Internal Error" });

        public Response(string[] errors, bool notFound = false)
        {
            Errors = errors;
            NotFound = notFound;
        }

        public Response(T data)
        {
            Data = data;
        }

        public string[] Errors { get; set; }
        public T Data { get; set; }
        public bool NotFound { get; set; } = false;

        public static Func<string, Response<T>> NotFoundError = (string id) =>
        {
            return new Response<T>(new string[] { $"the id \"{id}\" not found" });
        };

        public bool IsValid ()
        {
            return this.Errors == null || this.Errors.Count() > 0;
        }

        public override string ToString()
        {
            if (Errors == null || Errors.Length == 0)
            {
                return string.Empty;
            }

            StringBuilder strError = new StringBuilder();

            foreach (var err in Errors)
            {
                strError.AppendLine(err);
            }

            return strError.ToString();
        }
    }
}

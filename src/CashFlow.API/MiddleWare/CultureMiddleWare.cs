using System.Globalization;

namespace CashFlow.API.MiddleWare
{
    public class CultureMiddleWare
    {
        private readonly RequestDelegate _next;
        public CultureMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var culture = context.Request.Headers.AcceptLanguage.FirstOrDefault();
            CultureInfo cultureInfo = new("pt-BR");

            if (!string.IsNullOrWhiteSpace(culture))
            {
                cultureInfo = new CultureInfo(culture);
            }
            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;

            await _next(context);
        }
    }
}

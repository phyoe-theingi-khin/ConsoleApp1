namespace PTKDotNetCore.LoginApp.Middlewares
{
    public class CookieMiddleWare
    {
        private readonly RequestDelegate _next;

        public CookieMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            string url = context.Request.Path.ToString().ToLower();
            if (url == "/login" || url == "/login/index")
                goto result;
            string username = context.Request.Cookies["username"]!;
            if(string.IsNullOrEmpty(username))
            {
                context.Response.Redirect("/Login");
            }
            result:
            await _next(context);
        }
    }
}

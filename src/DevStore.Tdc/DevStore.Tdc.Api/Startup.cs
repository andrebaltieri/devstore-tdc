using Owin;

namespace DevStore.Tdc.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new DevStoreHttpConfiguration();
            app.UseWebApi(config);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Surging.Core.CPlatform.Transport.Implementation;

namespace Tax.CompanyModuleService.Services
{
    public class RpcProvider
    {
        public static KeyValuePair<string,object> GetRpcPayload()
        {
            //获取网关通过netty传递过来的参数
            var headRequest = RpcContext.GetContext().GetContextParameters().FirstOrDefault();
            return headRequest;
        }
    }
}
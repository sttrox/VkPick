using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using VkNet;

namespace VkPick.Utils
{
    public class Api
    {

  /// <summary>
        /// The instance
        /// </summary>
        private static VkApi _instance;

        /// <summary>
        /// Prevents a default instance of the <see cref="Api"/> class from being created.
        /// </summary>
        private Api()
        { }


        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static VkApi GetInstance(IServiceCollection collection = null)
        {
            return _instance ?? (_instance = new VkApi(collection));
        }
    }
}

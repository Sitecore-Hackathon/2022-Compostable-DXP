using Sitecore.DevEx.Configuration.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Primo.DevEx.Extensibility.Hackathon.Configuration
{
    public interface IEnvironmentConfigurationProvider
    {
        Task<EnvironmentConfiguration> GetEnvironmentConfigurationAsync(string currentDirectory, string environmentName);
    }
}

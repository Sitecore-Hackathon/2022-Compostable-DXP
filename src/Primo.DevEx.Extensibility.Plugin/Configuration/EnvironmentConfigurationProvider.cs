using Sitecore.DevEx.Configuration;
using Sitecore.DevEx.Configuration.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Primo.DevEx.Extensibility.Hackathon.Configuration
{
    public class EnvironmentConfigurationProvider : IEnvironmentConfigurationProvider
    {
        private readonly IRootConfigurationManager _rootConfigurationManager;

        public EnvironmentConfigurationProvider(IRootConfigurationManager rootConfigurationManager)
        {
            _rootConfigurationManager = rootConfigurationManager;
        }

        public async Task<EnvironmentConfiguration> GetEnvironmentConfigurationAsync(string currentDirectory, string environmentName)
        {
            var rootConfiguration = await _rootConfigurationManager.ResolveRootConfiguration(currentDirectory);

            if (!rootConfiguration.Environments.TryGetValue(environmentName, out var environmentConfiguration))
            {
                throw new InvalidConfigurationException($"Environment {environmentName} was not defined. Use the login command to define it.");
            }

            return environmentConfiguration;
        }
    }
}

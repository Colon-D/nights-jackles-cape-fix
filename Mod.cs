using Reloaded.Mod.Interfaces;
using nights.test.jacklescapefix.Template;
using nights.test.jacklescapefix.Configuration;

namespace nights.test.jacklescapefix;

/// <summary>
/// Your mod logic goes here.
/// </summary>
public class Mod : ModBase // <= Do not Remove.
{
    /// <summary>
    /// Provides access to the mod loader API.
    /// </summary>
    private readonly IModLoader _modLoader;

    /// <summary>
    /// Provides access to the Reloaded logger.
    /// </summary>
    private readonly ILogger _logger;

    /// <summary>
    /// Entry point into the mod, instance that created this class.
    /// </summary>
    private readonly IMod _owner;

    /// <summary>
    /// Provides access to this mod's configuration.
    /// </summary>
    private Config _configuration;

    /// <summary>
    /// The configuration of the currently executing mod.
    /// </summary>
    private readonly IModConfig _modConfig;

    public Mod(ModContext context)
    {
        _modLoader = context.ModLoader;
        _logger = context.Logger;
        _owner = context.Owner;
        _configuration = context.Configuration;
        _modConfig = context.ModConfig;


		// For more information about this template, please see
		// https://reloaded-project.github.io/Reloaded-II/ModTemplate/

		// If you want to implement e.g. unload support in your mod,
		// and some other neat features, override the methods in ModBase.

		unsafe {
            const int new_size = 512288;
            const int orig_size = 510464;
            int delta = new_size - orig_size; // 0x720;
			int* texture_ptr = (int*)0x8A2BD0;
            *texture_ptr += delta;
            int* rigging_ptr = (int*)(0x8A2BD0 + 4);
            *rigging_ptr += delta;
            int* animation_ptr = (int*)(0x8A2BD0 + 8);
            *animation_ptr += delta;
        }
	}

    #region Standard Overrides
    public override void ConfigurationUpdated(Config configuration)
    {
        // Apply settings from configuration.
        // ... your code here.
        _configuration = configuration;
        _logger.WriteLine($"[{_modConfig.ModId}] Config Updated: Applying");
    }
    #endregion

    #region For Exports, Serialization etc.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Mod() { }
#pragma warning restore CS8618
    #endregion
}

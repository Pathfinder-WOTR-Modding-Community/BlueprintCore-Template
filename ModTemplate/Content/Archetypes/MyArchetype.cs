using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Utils;

namespace ModTemplate.Content.Archetypes
{
  class MyArchetype
  {
    private static readonly string Name = "My Archetype";
    private static readonly string Description = "This is my Archetype. It is new!";
    private static readonly string Guid = "2E8F30C8-5224-4F74-A9B2-1A4F37638B7A";

    /// <summary>
    /// Configures MyArchetype
    /// </summary>
    public static void Configure()
    {
      // Creates an Archetype
      ArchetypeConfigurator.New(Name, Guid)
        // Don't tag names or weird things happen
        .SetDisplayName(LocalizationTool.CreateString(Name, Name, tagEncyclopediaEntries: false))
        .SetDescription(LocalizationTool.CreateString(Description, Description))
        .Configure();

      // Adds the archetype to the fighter class
      CharacterClassConfigurator.For(Guids.FighterClass).AddToArchetypes(Name).Configure();
    }
  }
}

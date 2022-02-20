using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;

namespace ModTemplate.Content.Feats
{
  class MySpell
  {
    private static readonly string Name = "My Feat";
    private static readonly string Description = "This is my feat. It is new!";
    private static readonly string Guid = "303B93CA-4CAC-4577-956F-84D7018B8906";

    /// <summary>
    /// Configures MyFeat
    /// </summary>
    public static void Configure()
    {
      // Creates a feat
      FeatureConfigurator.New(Name, Guid)
        .SetDisplayName(LocalizationTool.CreateString(Name, Name))
        .SetDescription(LocalizationTool.CreateString(Description, Description))
        .SetFeatureGroups(FeatureGroup.Feat)
        .Configure();

      // Adds the feat to the feat selection UI
      FeatureSelectionConfigurator.For(Guids.BasicFeatSelection).AddToFeatures(Name).Configure();
    }
  }
}

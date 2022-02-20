using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;

namespace ModTemplate.Content
{
  class MyClass
  {
    private static readonly string Name = "My Class";
    private static readonly string Description = "This is my Class. It is new!";
    private static readonly string Guid = "2BECD79C-BA4A-4BBC-A03A-AA167E958878";

    /// <summary>
    /// Configures MyClass
    /// </summary>
    public static void Configure()
    {
      // Creates a Class
      var myClass = CharacterClassConfigurator.New(Name, Guid)
        .SetLocalizedName(LocalizationTool.CreateString(Name, Name))
        .SetLocalizedDescription(LocalizationTool.CreateString(Description, Description))
        .Configure();

      // Adds the class to the class selection UI
      CommonTool.Append(
        BlueprintRoot.Instance.Progression.m_CharacterClasses,
        myClass.ToReference<BlueprintCharacterClassReference>());
    }
  }
}

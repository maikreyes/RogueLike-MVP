using System;
using System.Linq;
using NUnit.Framework;

namespace Game.Tests.Setup
{
    /// <summary>
    /// Pruebas de humo: confirman que el Unity Test Framework está bien configurado
    /// y que Tests.EditMode está conectado con el assembly del juego.
    /// </summary>
    public class TestSetupTests
    {
        [Test]
        public void TestFramework_RunsTests()
        {
            Assert.Pass("El Unity Test Framework ejecuta tests EditMode.");
        }

        [Test]
        public void GameAssembly_IsLoadedInEditor()
        {
            var gameAssembly = UnityEngine.Assemblies.CurrentAssemblies.GetLoadedAssemblies()
                .FirstOrDefault(assembly => assembly.GetName().Name == "Game");

            Assert.That(gameAssembly, Is.Not.Null,
                "El assembly 'Game' no está cargado. Revisa Assets/Scripts/Game.asmdef.");
        }

        [Test]
        public void GameAssembly_DoesNotIncludeTestCode()
        {
            var gameAssembly = UnityEngine.Assemblies.CurrentAssemblies.GetLoadedAssemblies()
                .First(assembly => assembly.GetName().Name == "Game");

            var referencesNUnit = gameAssembly
                .GetReferencedAssemblies()
                .Any(reference => reference.Name == "nunit.framework");

            Assert.That(referencesNUnit, Is.False,
                "El assembly del juego no debe depender de NUnit: el código de pruebas va en Assets/Tests.");
        }
    }
}
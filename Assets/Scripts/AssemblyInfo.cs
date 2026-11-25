using System.Runtime.CompilerServices;

// Permite que los tests accedan a miembros internal del juego
// sin tener que hacerlos public.
[assembly: InternalsVisibleTo("Tests.EditMode")]
[assembly: InternalsVisibleTo("Tests.PlayMode")]

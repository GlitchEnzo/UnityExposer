# UnityExposer
A set of libraries used to expose the internal Unity code.

The code is divided into the UnityEngine.Exposer and UnityEditor.Exposer namespaces.

If a public type already exists, but internal members need to be exposed to it, a new type called Exposed[OldTypeName] is created.

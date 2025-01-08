#if NET8_0_OR_GREATER
using System.Collections.Frozen;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
#else
using System.Collections.Immutable;
#endif

namespace PP.Integrator.ChangeTracking
{
	internal class ChangeDispatcherBuilder : IChangeDispatcherBuilder
	{		
		Dictionary<string, Box> trackings = new Dictionary<string, Box>();		
		public IChangeDispatcherBuilder TrackChangesOf<Item>() where Item : class
		{
			var name = TypeHelper<Item>.Name;
			// тут остается опасность того что может попасться класс с идентичным именем просто в другом неймспейсе, но сейчас это не самое главное
			var provider = new ChangeProvider<Item>();
			trackings.Add(name, Box.Create(provider));			
			return this;
		}

		public ChangeDispatcher Build()
		{
			var types = 
#if NET8_0_OR_GREATER
			trackings.ToFrozenDictionary(StringComparer.InvariantCultureIgnoreCase);
#else
			trackings.ToImmutableDictionary(StringComparer.InvariantCultureIgnoreCase);
#endif
			return new ChangeDispatcher(types);
		}
	}	
}

using UnityEngine;
using Robotlegs.Bender.Framework.API;
using Robotlegs.Bender.Framework.Impl;
using helloworldmulticontext.config;
using Robotlegs.Bender.Platforms.Unity.Extensions.ContextViews.Impl;
using Robotlegs.Bender.Platforms.Unity.Bundles;

namespace helloworldmulticontextdifferentroots
{
	public class ParentContextDifferentRoots : MonoBehaviour
	{
		[SerializeField]
		private ContextHolder[] _childContextHolders;

		IContext parentContext;

		public void Start()
		{
			// A parent context, handles relationship of child / parent communication
			// It becomes parent when it's child contexts boot up and find that this context's view is parent of them
			parentContext = new Context ();

			foreach (ContextHolder child in _childContextHolders)
				parentContext.AddChild(child.Context);
			
			parentContext.Install<UnityMultiContextBundle> () // Install MVCS Framework
				.Configure(new TransformContextView(transform));

			parentContext.AfterInitializing (InitializeChildContexts);
		}

		private void InitializeChildContexts()
		{
			foreach (ContextHolder child in _childContextHolders) 
			{
				child.Initialize ();
			}
		}
	}
}


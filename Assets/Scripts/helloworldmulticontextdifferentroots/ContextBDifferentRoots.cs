using UnityEngine;
using helloworldmulticontext.config;
using helloworld.views;
using Robotlegs.Bender.Extensions.EventManagement.API;
using Robotlegs.Bender.Framework.API;
using Robotlegs.Bender.Framework.Impl;
using Robotlegs.Bender.Platforms.Unity.Extensions.ContextViews.Impl;
using Robotlegs.Bender.Extensions.Modularity;
using Robotlegs.Bender.Platforms.Unity.Bundles;

namespace helloworldmulticontextdifferentroots
{
	public class ContextBDifferentRoots : ContextHolder
	{
		public void Awake()
		{
			Context = new Context ();
			Context.Install<UnityMultiContextBundle> () // Install MVCS Framework
				.Configure<SendMessageConfig>() // Sets up the send message mediator configuration
				.Configure<MessageEventRelay>() // Relays message events to a channel ready for another context to receive
				.Configure<HelloWorldMappingConfig>() // Sets up the hello world model & mediator
				.Configure<AddSendMessageButton>() // Adds the send message button
				.Configure<AddHelloWorldButtons>(); // Adds the hello world click and display button
		}

		public override void Initialize ()
		{
			Context.Configure (new TransformContextView (this.transform)); // Set this transform to boot up the application when it's alive
		}
	}
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;

namespace KickOnItemBan
{
	[ApiVersion(2, 0)]
    public class KickOnItemBan : TerrariaPlugin
    {
		public override string Name
		{
			get { return "KickOnItemBan"; }
		}

		public override Version Version
		{
			get { return new Version(1, 0, 0); }
		}

		public override string Author
		{
			get { return "Onsen"; }
		}

		public override string Description
		{
			get { return "Kick on holding banned item"; }
		}

		public KickOnItemBan(Main game) : base(game)
		{

		}

		public override void Initialize()
		{
			ServerApi.Hooks.GameUpdate.Register(this, OnUpdate);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				ServerApi.Hooks.GameUpdate.Deregister(this, OnUpdate);
			}
			base.Dispose(disposing);
		}

		// The following code is borrowed from 'TShock/TShockAPI/TShock.cs'.

		private DateTime LastCheck = DateTime.UtcNow;

		private void OnUpdate(EventArgs args)
		{
			if ((DateTime.UtcNow - LastCheck).TotalSeconds >= 1)
			{
				OnSecondUpdate();
				LastCheck = DateTime.UtcNow;
			}
		}

		private void OnSecondUpdate()
		{
			foreach (TSPlayer player in TShock.Players)
			{
				if (player != null && player.Active)
				{
					if (TShock.Itembans.ItemIsBanned(player.TPlayer.inventory[player.TPlayer.selectedItem].name, player))
					{
						TShock.Utils.Kick(player, string.Format("Holding banned item: {0}", player.TPlayer.inventory[player.TPlayer.selectedItem].name));
					}
				}
			}
		}
	}
}

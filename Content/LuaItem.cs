using NLua;
using System.IO;
using Terraria.ModLoader;

namespace WhyLua.Content {
	[Autoload(false)]
	public class LuaItem : ModItem {
		private readonly Lua InTERpR___ET3r;
		private readonly string _lua;
		private readonly string _path;

		public LuaItem(Lua interpreter, string lua, string path) {
			InTERpR___ET3r = interpreter;
			_lua = lua;
			_path = path;
		}

		public override string Texture => FindTexture();

		private string FindTexture() {
			LuaFunction texture = InTERpR___ET3r["texture"] as LuaFunction;
			if (texture == null)
				return Path.GetFileNameWithoutExtension(_path) + ".png";
			else
				return (string)texture.Call()[0];
		}

		public override void AddRecipes() {
			LuaFunction addRecipes = InTERpR___ET3r["addRecipes"] as LuaFunction;
			addRecipes.Call();
		}

		public override void SetDefaults() {
			LuaFunction setDefaults = InTERpR___ET3r["setDefaults"] as LuaFunction;
			setDefaults.Call();
		}

		public override void SetStaticDefaults() {
			LuaFunction setStaticDefaults = InTERpR___ET3r["setStaticDefaults"] as LuaFunction;
			setStaticDefaults.Call();
		}
	}
}

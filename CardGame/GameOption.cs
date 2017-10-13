using System.Reflection;
using System.Collections;

namespace CardGame
{
    /// <summary>
    /// GameOption class for creation of custom enumeration of per-game options
    /// </summary>
    public abstract class GameOption
    {
        public string Value { get; private set; }

        public override string ToString()
        {
            return Value;
        }

        protected GameOption(string value)
        {
            this.Value = value.ToUpper();
        }

        /// <summary>
        /// Returns list of possible game options
        /// </summary>
        /// <see cref="https://stackoverflow.com/questions/4994469/loop-through-constant-members-of-a-class"/>
        /// <returns>All const fields from the current GameOption object</returns>
        protected static GameOption[] GetConstantOptions(System.Type type)
        {
            ArrayList constants = new ArrayList();

            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

            foreach(FieldInfo fi in fieldInfos)
            {
                if(!fi.IsLiteral && fi.IsInitOnly)
                {
                    constants.Add(fi.GetValue(type));
                }
            }

            return (GameOption[])constants.ToArray(typeof(GameOption));
        }

        protected static GameOption GetOption(string optionName, System.Type type)
        {
            GameOption[] constants = GetConstantOptions(type);
            foreach(GameOption option in constants)
            {
                if(option.Value == optionName)
                {
                    return option;
                }
            }
            return null;
        }
    }
}

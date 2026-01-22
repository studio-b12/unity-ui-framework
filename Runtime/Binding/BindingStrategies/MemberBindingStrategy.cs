using System;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents a binding strategy that binds to a specific member of an object.
    /// </summary>
    public class MemberBindingStrategy : IBindingStrategy
    {
        private readonly BindedMember member;
        
        private IValueConverter converter;
        
        public event Action GotDirty;

        public MemberBindingStrategy(Func<object> getOriginFunction, string memberPath)
        {
            member = new BindedMember(getOriginFunction, memberPath);
            member.GotDirty += OnMemberGotDirty;
        }
        
        public void SetConverter(IValueConverter converter)
        {
            this.converter = converter;
        }

        public void Evaluate()
        {
            member.Evaluate();
        }
        
        public void Release()
        {
            member.Release();
        }

        public object Get()
        {
            object value = member.Get();
            
            if (converter != null)
            {
                value = converter.Convert(value);
            }

            return value;
        }

        public void Set(object value)
        {
            if (converter != null)
            {
                value = converter.ConvertBack(value);
            }
            
            member.Set(value);
        }

        private void OnMemberGotDirty()
        {
            GotDirty?.Invoke();
        }
    }
}
#region using directives

using System;
using System.ComponentModel;

#endregion

namespace ShopManager.Controls.Basic
{
    internal class CustomPropertyDescriptor : PropertyDescriptor
    {
        private readonly PropertyDescriptor _propertyDescriptor;

        public CustomPropertyDescriptor(string name, PropertyDescriptor propertyDescriptor, Attribute[] attrs)
            : base(name, attrs)
        {
            _propertyDescriptor = propertyDescriptor;
        }

        public override Type ComponentType
        {
            get { return _propertyDescriptor.ComponentType; }
        }

        public override bool IsReadOnly
        {
            get { return _propertyDescriptor.IsReadOnly; }
        }

        public override Type PropertyType
        {
            get { return _propertyDescriptor.PropertyType; }
        }

        public override bool CanResetValue(object component)
        {
            return _propertyDescriptor.CanResetValue(component);
        }

        public override object GetValue(object component)
        {
            return _propertyDescriptor.GetValue(component);
        }

        public override void ResetValue(object component)
        {
            _propertyDescriptor.ResetValue(component);
        }

        public override void SetValue(object component, object value)
        {
            _propertyDescriptor.SetValue(component, value);
        }

        public override bool ShouldSerializeValue(object component)
        {
            return _propertyDescriptor.ShouldSerializeValue(component);
        }
    }
}
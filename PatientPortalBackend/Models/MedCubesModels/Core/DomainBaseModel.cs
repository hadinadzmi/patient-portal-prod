using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;

namespace PatientPortalBackend.Models.MedCubesModels.Core
{
    [DataContract(Name = "DomainBaseModel", Namespace = "MedCubes.Framework.Models")]
    public abstract partial class DomainBaseModel : ModelBase, IDisposable
#if SILVERLIGHT
        , INotifyPropertyChanged
#endif

    {
        [DataMember]
        public long CustomerId
        {
            get;
            set;
        }
        [DataMember]
        public long TenantId
        {
            get;
            set;
        }

        public List<DomainBaseModel> ToList()
        {
            return new List<DomainBaseModel>() { this };

        }
        public readonly string ModifiableProperties = "";

        public T ShallowCopy<T>()
        {
            return (T)MemberwiseClone();
        }


        /// <summary>
        /// This method returns the specific key from an instance for the history. Must be overwritten in subclasses.
        /// </summary>
        /// <returns></returns>
        public virtual string GetHistoryKey()
        {
            try
            {
                return this["PkId"].ToString();
            }
            catch (Exception)
            {
                throw new Exception(string.Format("The property 'PkId' is not available in '{0}'! (Try override GetHistoryKey-method)", GetType()));
            }
        }

        private void FillCustomerId(DomainBaseModel model)
        {

        }

        private void FillTenantId(DomainBaseModel model)
        {
        }
        [DataMember]
        public ModelState State { get; set; }

        /// <summary>
        /// Base constructor. Initializes an instance with its state as "added".
        /// </summary>
        protected DomainBaseModel()
        {
            State = ModelState.Unchanged;
            FillCustomerId(this);
            FillTenantId(this);
        }

        /// <summary>
        /// This property holds the originalvalues of an instance. The original values are created when
        /// someone calls FinishInitialization() on an instance.
        /// </summary>
        [JsonIgnore]
        public DomainBaseModel OriginalValue { get; set; }


        /// <summary>
        /// This method checks if the passed reference is already in the list.
        /// If the reference cannot be found, than the reference is added to the internal list.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="temp"></param>
        /// <returns></returns>
        private static bool GetFound(IEnumerable<DomainBaseModel> list, DomainBaseModel temp)
        {
            if (temp == null)
            {
                return true;
            }
            return list.Any(haBase => ReferenceEquals(haBase, temp));
        }


        #region CompareFunctions

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var target = obj as DomainBaseModel;

            return this == target;
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="dbo1">The first model.</param>
        /// <param name="dbo2">The second model.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(DomainBaseModel dbo1, DomainBaseModel dbo2)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(dbo1, dbo2))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if ((object)dbo1 == null || (object)dbo2 == null)
            {
                return false;
            }

            var ownId = dbo1.GetHistoryKey() != string.Empty ? dbo1.GetHistoryKey() : dbo1.GetHashCode().ToString();
            var targetId = dbo2.GetHistoryKey() != string.Empty ? dbo2.GetHistoryKey() : dbo2.GetHashCode().ToString();

            var ownRowVersion = dbo1["RowVersion"] as byte[];
            var targetRowVersion = dbo2["RowVersion"] as byte[];

            // Special case: one rowversion is null the other one is set (happens during create for example)
            if (ownRowVersion == null || targetRowVersion == null) // Revert of == != fix, this crashes the selection logic for dialogs?! 
            {
                return false;
            }

            // Added the ownRowVersion == targetRowVersion check when both are null -> unit testing support!
            return ownId == targetId &&
                    (ownRowVersion == targetRowVersion || ownRowVersion.SequenceEqual(targetRowVersion));
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="p1">The first model.</param>
        /// <param name="p2">The second model.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(DomainBaseModel p1, DomainBaseModel p2)
        {
            return !(p1 == p2);
        }

        // Included to remove warnings
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion CompareFunctions


        public virtual ModelValidationResult ValidateModel()
        {
            return new ModelValidationResult();
        }

        public void Dispose()
        {
#if SILVERLIGHT
            PropertyChanged = null;
#endif
        }
    }




    /// <summary>
    /// This abstract class provides the implementation of property-access via indexer.
    /// </summary>
    [DataContract(Name = "ModelBase", Namespace = "MedCubes.Framework.Models")]
    public abstract class ModelBase
    {
        /// <summary>
        /// Gets or sets the specified property of the <see cref="object" />.
        /// </summary>
        /// <value>
        /// The <see cref="object" />.
        /// </value>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        [JsonIgnore]
        public object this[string propertyName]
        {
            get
            {
                return PropHelper.GetProperty(this, propertyName);
            }
            set
            {
                PropHelper.SetProperty(this, propertyName, value);
            }
        }
    }

    public static class PropHelper
    {
        public static void InvokeSetterOfProperty<T, TU>(T model, PropertyInfo pi, TU value)
        {
            if (pi != null)
            {
                var mi = pi.GetSetMethod();
                if (mi != null)
                {
                    mi.Invoke(model, new object[] { value });
                }
            }
        }

        public static PropertyInfo GetInfoAboutProperty<T>(T model, string property)
        {
            return model.GetType().GetProperty(property, BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
        }

        public static MethodInfo GetInfoAboutMethod<T>(T model, string methodName)
        {
            return model.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
        }

        public static object GetProperty(object source, string propertyName)
        {
            var propertyInfo = source.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
            if (propertyInfo == null)
            {
                //if (propertyName != "DynamicFields")
                //    throw new ArgumentException(string.Format("Property '{0}' not found!", propertyName));
                return null;
            }

            return propertyInfo.GetValue(source, null);
        }

        public static string GetPropertyAsString(object source, string propertyName)
        {
            var value = GetProperty(source, propertyName);
            return value == null ? null : value.ToString();
        }


        public static bool GetProperty<T>(object source, string propertyName, out T result)
        {
            result = default;
            var value = GetProperty(source, propertyName);
            try
            {
                result = (T)value;
                return true;
            }
            catch (Exception) { }

            return false;
        }

        public static void SetProperty(object source, string propertyName, object value)
        {
            var propertyInfo = source.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);
            if (propertyInfo == null)
            {
                //if (propertyName != "DynamicFields")
                //    throw new ArgumentException(string.Format("Property '{0}' not found!", propertyName));
                return;
            }

            var castedSource = Convert.ChangeType(source, source.GetType(), CultureInfo.InvariantCulture);
            var propertyTypeOfSourceProperty = castedSource.GetType().GetProperty(propertyName).PropertyType;

            // Special case DateTimeOffset -> not directly assignable, parsing needed
            // Also handle DateTimeOffset? with the null value as special case!
            if (propertyTypeOfSourceProperty == typeof(DateTimeOffset) ||
                propertyTypeOfSourceProperty == typeof(DateTimeOffset?))
            {
                if (value == null)
                {
                    propertyInfo.SetValue(source, null, null);
                }
                else
                {
                    DateTimeOffset dateTimeOffset;
                    if (DateTimeOffset.TryParse(value.ToString(), out dateTimeOffset))
                    {
                        propertyInfo.SetValue(source, dateTimeOffset, null);
                    }
                }
            }
            else if (value != null)
            {
                object castedValue = null;

                if (value is Guid) // Handle Guid Special Edge Cases
                {
                    // Assign Guid to string
                    if (propertyTypeOfSourceProperty == typeof(string))
                    {
                        castedValue = value.ToString();
                    }
                    // Assign Guid to Guid or Guid? -> Does not work with conversion!
                    else if (propertyTypeOfSourceProperty == typeof(Guid) || propertyTypeOfSourceProperty == typeof(Guid?))
                    {
                        castedValue = value;
                    }
                }
                else if (value is ModelBase)
                {
                    castedValue = value;
                }
                else
                {
                    if (IsGenericListProperty(propertyInfo.PropertyType))
                    {
                        if (ProcessGenericListProperty(propertyInfo, source, value as IEnumerable, propertyTypeOfSourceProperty)) return;
                    }
                    else if (propertyTypeOfSourceProperty == typeof(string) && IsDateTimeObject(value))
                    {
                        castedValue = value.ToString();
                    }
                    else
                    {
                        castedValue = Convert.ChangeType(value, propertyTypeOfSourceProperty, CultureInfo.InvariantCulture);
                    }
                }

                if (castedValue is double)
                {
                    //first fixing of '.' vs. ',' in double parsing... -> allow both
                    var castedValueOtherCultureInfo = Convert.ChangeType(value, propertyTypeOfSourceProperty, CultureInfo.CurrentCulture);
                    if ((double)castedValueOtherCultureInfo < (double)castedValue)
                        castedValue = castedValueOtherCultureInfo;
                }
                propertyInfo.SetValue(source, castedValue, null);
            }
            else
            {
                try
                {
                    propertyInfo.SetValue(source, null, null);
                }
                catch (Exception)
                {
                }
            }


            //double tryParseDouble;
            //if (IsNumericType(propertyInfo.PropertyType) && value != null && double.TryParse(value.ToString(), out tryParseDouble))
            //{
            //    var number = Convert.ChangeType(tryParseDouble, propertyInfo.PropertyType, CultureInfo.InvariantCulture);

            //    propertyInfo.SetValue(source, number, null);
            //    return;
            //}

            //DateTime tryParseDateTime;
            //if (IsDateTimeType(propertyInfo.PropertyType) && value != null && DateTime.TryParse(value.ToString(), out tryParseDateTime))
            //{
            //    var date = Convert.ChangeType(tryParseDateTime, propertyInfo.PropertyType, CultureInfo.InvariantCulture);
            //    propertyInfo.SetValue(source, date, null);
            //    return;
            //}

            //propertyInfo.SetValue(source, value, null);
        }

        private static bool IsDateTimeObject(object obj)
        {
            if (obj is DateTimeOffset || obj is DateTime)
                return true;

            return false;
        }

        private static bool IsGenericListProperty(Type t)
        {
            return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(List<>);
        }

        private static bool ProcessGenericListProperty(PropertyInfo propertyInfo, object source, IEnumerable value, Type t)
        {
            try
            {
                var theList = propertyInfo.GetValue(source, null) as IList;
                if (theList == null)
                {
                    if (value != null)
                    {
                        theList = Activator.CreateInstance(t) as IList;
                    }

                    var setMethod = source.GetType().GetProperty(propertyInfo.Name).GetSetMethod();
                    if (setMethod != null)
                    {
                        setMethod.Invoke(source, new object[] { theList });
                    }
                }
                else
                {
                    theList.Clear();
                }

                if (value == null) return true;

                if (theList != null)
                {
                    foreach (var listItem in value)
                    {
                        theList.Add(listItem);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }

        }

        public static bool IsNumericType(Type type)
        {
            if (type == null)
            {
                return false;
            }

            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
                case TypeCode.Object:
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        return IsNumericType(Nullable.GetUnderlyingType(type));
                    }
                    return false;
            }
            return false;
        }


        private static bool IsDateTimeType(Type type)
        {
            if (type == null)
                return false;

            switch (Type.GetTypeCode(type))
            {
                case TypeCode.DateTime:
                    return true;
                case TypeCode.Object:
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        return IsDateTimeType(Nullable.GetUnderlyingType(type));
                    }
                    return false;
            }
            return false;
        }
    }

    [DataContract(Name = "ModelState", Namespace = "MedCubes.Framework.Models")]
    public enum ModelState
    {
        /// <summary>
        /// Dummy entry for serializing
        /// </summary>
        [EnumMember]
        Unused = 0,

        /// <summary>
        /// This entry flags an instance as detached
        /// </summary>
        [EnumMember]
        Detached = 1,

        /// <summary>
        /// This entry flags an instance as unchanged.
        /// </summary>
        [EnumMember]
        Unchanged = 2,

        /// <summary>
        /// This entry flags an instance as added (=new)
        /// </summary>
        [EnumMember]
        Added = 4,

        /// <summary>
        /// This entry flags an instance as deleted
        /// </summary>
        [EnumMember]
        Deleted = 8,

        /// <summary>
        /// This entry flags an instance as modified
        /// </summary>
        [EnumMember]
        Modified = 16,

        /// <summary>
        /// This entry flags an instance as unchanged.
        /// </summary>
        [EnumMember]
        Read = 32,

        /// <summary>
        /// This entry flags an instance as unchanged.
        /// </summary>
        [EnumMember]
        ModifiedWithConflict = 64
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PatientPortalBackend.Models.MedCubesModels.Core
{
    [DataContract(Namespace = "www.Ahcs.co/MedCubes/Wcf/Messages")]
    [ZeroFormatter.ZeroFormattable]
    public class ModelValidationResult
    {
        /// <summary>
        /// 
        /// </summary>
        public ModelValidationResult()
        {
        }

        /// <summary>
        /// Indicates wether errors were found or just warnings.
        /// </summary>
        [DataMember]
        [ZeroFormatter.Index(0)]
        public virtual bool HasWarningsOnly { get; set; }

        /// <summary>
        /// Indicates if validation errors occurred.
        /// </summary>
        /// <returns>true if warnings/errors were found in the model.</returns>
        [DataMember]
        [ZeroFormatter.IgnoreFormat]
        public bool HasValidationErrors
        {
            get
            {
                return ValidationDict != null && ValidationDict.Count > 0 && !HasWarningsOnly;
            }
            set { }
        }

        /// <summary>
        /// Returns all entries of the dictionary in one single string.
        /// </summary>
        /// <returns></returns>
        public string GetErrorsAsText()
        {

            var err = ValidationDict.Values;

            if (err == null || err.Count == 0) return string.Empty;

            var buff = new StringBuilder();
            foreach (var er in err)
            {
                er.ForEach(p => buff.AppendLine(p));
            }
            return buff.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, List<string>> _validationDict;

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [ZeroFormatter.Index(1)]
        public virtual Dictionary<string, List<string>> ValidationDict
        {
            get
            {
                if (_validationDict == null)
                    _validationDict = new();

                return _validationDict;
            }
            set
            {
                _validationDict = value;
            }
        }

        /// <summary>
        /// This methods checks if the property is already in the dictionary. 
        /// If not, an entry with the errortext will be created.
        /// Otherwise the error messages will be added.
        /// </summary>
        /// <param name="propertyName">The name of the property to check (if it is in the dictionary)</param>
        /// <param name="error">The errortext to add to the property</param>
        public void AddError(string propertyName, string error)
        {
            AddErrorList(propertyName, new List<string>() { error });
        }

        /// <summary>
        /// This methods checks if the property is already in the dictionary. 
        /// If not, an entry with the errortext will be created. 
        /// Otherwise the error messages will be added.
        /// </summary>
        /// <param name="propertyName">The name of the property to check (if it is in the dictionary)</param>
        /// <param name="errorList">The list of error messages to add to the property</param>
        public void AddErrorList(string propertyName, List<string> errorList)
        {
            if (!ValidationDict.ContainsKey(propertyName))
                ValidationDict.Add(propertyName, new List<string>());
            ValidationDict[propertyName].AddRange(errorList);
        }


        public void AddCompleteResult(ModelValidationResult additionalResult)
        {
            foreach (var errors in additionalResult.ValidationDict)
            {
                AddErrorList(errors.Key, errors.Value);
            }
        }


        public void Clear()
        {
            ValidationDict.Clear();
        }

        public void ClearWithoutCustomValidations()
        {
            ValidationDict = ValidationDict.Where(p => p.Key.StartsWith("<<customValidation>>"))
                .ToDictionary(p => p.Key, p => p.Value);
        }

        public void ClearCustomValidations(string specificLabel = "")
        {
            ValidationDict = ValidationDict.Where(p => !p.Key.StartsWith("<<customValidation>>" + specificLabel))
                .ToDictionary(p => p.Key, p => p.Value);
        }

        /// <summary>
        /// Returns a list of all entries for a specified property.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public List<string> GetEntriesForProperty(string propertyName)
        {
            if (HasValidationErrors)
            {
                List<string> entriesForProperty;
                if (ValidationDict.TryGetValue(propertyName, out entriesForProperty))
                {
                    return entriesForProperty;
                }
            }
            return null;
        }
    }
}

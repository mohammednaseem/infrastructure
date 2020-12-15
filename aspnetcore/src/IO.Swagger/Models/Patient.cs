/*
 * Healthcare
 *
 * This is a API built for demo purpose. About patients and their treatment plan.
 *
 * OpenAPI spec version: 1.0.3
 * Contact: m.naseem@outlook.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Patient : IEquatable<Patient>
    { 
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [Required]
        [DataMember(Name="id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [Required]
        [DataMember(Name="name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets TotalWeightInKilos
        /// </summary>
        [Required]
        [DataMember(Name="totalWeightInKilos")]
        public int? TotalWeightInKilos { get; set; }

        /// <summary>
        /// Gets or Sets Classification
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum ClassificationEnum
        {
            /// <summary>
            /// Enum UnderweightEnum for Underweight
            /// </summary>
            [EnumMember(Value = "Underweight")]
            UnderweightEnum = 0,
            /// <summary>
            /// Enum NormalEnum for Normal
            /// </summary>
            [EnumMember(Value = "Normal")]
            NormalEnum = 1,
            /// <summary>
            /// Enum OverweightEnum for Overweight
            /// </summary>
            [EnumMember(Value = "Overweight")]
            OverweightEnum = 2,
            /// <summary>
            /// Enum ObeseEnum for Obese
            /// </summary>
            [EnumMember(Value = "Obese")]
            ObeseEnum = 3        }

        /// <summary>
        /// Gets or Sets Classification
        /// </summary>
        [Required]
        [DataMember(Name="classification")]
        public List<ClassificationEnum> Classification { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Patient {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  TotalWeightInKilos: ").Append(TotalWeightInKilos).Append("\n");
            sb.Append("  Classification: ").Append(Classification).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Patient)obj);
        }

        /// <summary>
        /// Returns true if Patient instances are equal
        /// </summary>
        /// <param name="other">Instance of Patient to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Patient other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) && 
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) && 
                (
                    TotalWeightInKilos == other.TotalWeightInKilos ||
                    TotalWeightInKilos != null &&
                    TotalWeightInKilos.Equals(other.TotalWeightInKilos)
                ) && 
                (
                    Classification == other.Classification ||
                    Classification != null &&
                    Classification.SequenceEqual(other.Classification)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                    if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                    if (TotalWeightInKilos != null)
                    hashCode = hashCode * 59 + TotalWeightInKilos.GetHashCode();
                    if (Classification != null)
                    hashCode = hashCode * 59 + Classification.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Patient left, Patient right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Patient left, Patient right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}

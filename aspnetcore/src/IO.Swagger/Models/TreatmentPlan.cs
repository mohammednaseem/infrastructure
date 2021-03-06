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
    public partial class TreatmentPlan : IEquatable<TreatmentPlan>
    { 
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [Required]
        [DataMember(Name="id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or Sets PatientId
        /// </summary>
        [Required]
        [DataMember(Name="patientId")]
        public Guid? PatientId { get; set; }

        /// <summary>
        /// Gets or Sets DoctorId
        /// </summary>
        [Required]
        [DataMember(Name="doctorId")]
        public Guid? DoctorId { get; set; }

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
        [DataMember(Name="classification")]
        public List<ClassificationEnum> Classification { get; set; }

        /// <summary>
        /// Gets or Sets Prescription
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum PrescriptionEnum
        {
            /// <summary>
            /// Enum NoneEnum for None
            /// </summary>
            [EnumMember(Value = "None")]
            NoneEnum = 0,
            /// <summary>
            /// Enum EatEggsEnum for Eat eggs
            /// </summary>
            [EnumMember(Value = "Eat eggs")]
            EatEggsEnum = 1,
            /// <summary>
            /// Enum Run5MilesEnum for Run 5 miles
            /// </summary>
            [EnumMember(Value = "Run 5 miles")]
            Run5MilesEnum = 2,
            /// <summary>
            /// Enum Run15MilesEnum for Run 15 miles
            /// </summary>
            [EnumMember(Value = "Run 15 miles")]
            Run15MilesEnum = 3        }

        /// <summary>
        /// Gets or Sets Prescription
        /// </summary>
        [DataMember(Name="prescription")]
        public List<PrescriptionEnum> Prescription { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TreatmentPlan {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  PatientId: ").Append(PatientId).Append("\n");
            sb.Append("  DoctorId: ").Append(DoctorId).Append("\n");
            sb.Append("  Classification: ").Append(Classification).Append("\n");
            sb.Append("  Prescription: ").Append(Prescription).Append("\n");
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
            return obj.GetType() == GetType() && Equals((TreatmentPlan)obj);
        }

        /// <summary>
        /// Returns true if TreatmentPlan instances are equal
        /// </summary>
        /// <param name="other">Instance of TreatmentPlan to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TreatmentPlan other)
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
                    PatientId == other.PatientId ||
                    PatientId != null &&
                    PatientId.Equals(other.PatientId)
                ) && 
                (
                    DoctorId == other.DoctorId ||
                    DoctorId != null &&
                    DoctorId.Equals(other.DoctorId)
                ) && 
                (
                    Classification == other.Classification ||
                    Classification != null &&
                    Classification.SequenceEqual(other.Classification)
                ) && 
                (
                    Prescription == other.Prescription ||
                    Prescription != null &&
                    Prescription.SequenceEqual(other.Prescription)
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
                    if (PatientId != null)
                    hashCode = hashCode * 59 + PatientId.GetHashCode();
                    if (DoctorId != null)
                    hashCode = hashCode * 59 + DoctorId.GetHashCode();
                    if (Classification != null)
                    hashCode = hashCode * 59 + Classification.GetHashCode();
                    if (Prescription != null)
                    hashCode = hashCode * 59 + Prescription.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(TreatmentPlan left, TreatmentPlan right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TreatmentPlan left, TreatmentPlan right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CloudEventData;

public class CloudEventRequest
{
    #region Required fields
    
    /// <summary>
    /// Unique identifier for the event within the scope of the producer.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// The source of the event. Must be a non-empty URI-reference.
    /// An absolute URI is recommended.
    /// Examples:
    /// https://github.com/cloudevents
    /// sensors/tn-1234567/alerts
    /// </summary>
    [JsonPropertyName("source")]
    public Uri Source { get; set; }

    /// <summary>
    /// The version of the CloudEvents specification which the event uses.
    /// This enables the interpretation of the context.
    /// Compliant event producers MUST use a value of 1.0 when referring to this version of the specification.
    /// </summary>
    [JsonPropertyName("specversion")]
    public string SpecVersion { get; set; }

    /// <summary>
    /// Describes the type of event related to the originating occurrence.
    /// Often used for routing, observability, policy enforcement, etc.
    /// The format is producer-defined and might include version information.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    #endregion
    
    #region Optional fields
    
    /// <summary>
    /// The content type of the data being sent. Example: 'application/json'.
    /// </summary>
    [JsonPropertyName("datacontenttype")]
    public string? DataContentType { get; set; }

    /// <summary>
    /// Identifies the schema that the data adheres to.
    /// Incompatible changes to the schema should be reflected by a different URI.
    /// </summary>
    [JsonPropertyName("dataschema")]
    public Uri? DataSchema { get; set; }

    /// <summary>
    /// Describes the subject of the event in the context of the event producer.
    /// </summary>
    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    /// <summary>
    /// Timestamp of when the occurrence happened.
    /// </summary>
    [JsonPropertyName("time")]
    public DateTime? Time { get; set; }

    /// <summary>
    /// The event payload. This specification does not restrict the type of this information.
    /// It is encoded into a media format specified by the DataContentType attribute (e.g., application/json),
    /// and adheres to the DataSchema format when those respective attributes are present.
    /// </summary>
    [JsonPropertyName("data")]
    public dynamic? Data { get; set; }
    
    #endregion

    /// <summary>
    /// A dictionary to hold any extra fields that are not mapped to the above properties.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement> ExtraFields { get; set; }
}

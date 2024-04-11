using Cuemon.Configuration;

namespace Codebelt.SharedKernel
{
    /// <summary>
    /// Configuration options for <see cref="Token"/>.
    /// </summary>
    public class TokenOptions : IParameterObject
    {
        private byte _maximumCharacterFrequency;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenOptions"/> class.
        /// </summary>
        /// <remarks>
        /// The following table shows the initial property values for an instance of <see cref="TokenOptions"/>.
        /// <list type="table">
        ///     <listheader>
        ///         <term>Property</term>
        ///         <description>Initial Value</description>
        ///     </listheader>
        ///     <item>
        ///         <term><see cref="MinimumLength"/></term>
        ///         <description>32</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="MaximumLength"/></term>
        ///         <description>128</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="MaximumCharacterFrequency"/></term>
        ///         <description>4</description>
        ///     </item>
        /// </list>
        /// </remarks>
        public TokenOptions()
        {
            MinimumLength = 32;
            MaximumLength = 128;
            MaximumCharacterFrequency = 4;
        }

        /// <summary>
        /// Gets or sets the minimum length of the <see cref="Token"/>.
        /// </summary>
        /// <value>The minimum length of the <see cref="Token"/>.</value>
        public byte MinimumLength { get; set; }

        /// <summary>
        /// Gets or sets the maximum length of the <see cref="Token"/>.
        /// </summary>
        /// <value>The maximum length of the <see cref="Token"/>.</value>
        public byte MaximumLength { get; set; }

        /// <summary>
        /// Gets or sets the maximum character frequency of the <see cref="Token"/>.
        /// </summary>
        /// <value>The maximum character frequency of the <see cref="Token"/>.</value>
        /// <remarks>In the event that <see cref="MaximumCharacterFrequency"/> is greater than the <see cref="MinimumLength"/>, it will be set to the <see cref="MinimumLength"/>.</remarks>
        public byte MaximumCharacterFrequency
        {
            get
            {
                if (_maximumCharacterFrequency > MinimumLength) { _maximumCharacterFrequency = MinimumLength; }
                return _maximumCharacterFrequency;
            }
            set => _maximumCharacterFrequency = value;
        }
    }
}

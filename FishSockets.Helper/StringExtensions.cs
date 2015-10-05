//*******************************************************************************************************
//  StringExtensions.cs - Gbtc
//
//  Tennessee Valley Authority, 2009
//  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
//
//  This software is made freely available under the TVA Open Source Agreement (see below).
//  Code in this file licensed to TVA under one or more contributor license agreements listed below.
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  02/23/2003 - J. Ritchie Carroll
//       Generated original version of source code.
//  01/24/2006 - J. Ritchie Carroll
//       Migrated 2.0 version of source code from 1.1 source (TVA.Shared.String).
//  06/01/2006 - J. Ritchie Carroll
//       Added ParseBoolean function to parse strings representing booleans that may be numeric.
//  07/07/2006 - J. Ritchie Carroll
//       Added GetStringSegments function to break a string up into smaller chunks for parsing.
//       and/or displaying.
//  08/02/2007 - J. Ritchie Carroll
//       Added a CenterText method for centering strings in console applications or fixed width fonts.
//  08/03/2007 - Pinal C. Patel
//       Modified the CenterText method to handle multiple lines.
//  08/21/2007 - Darrell Zuercher
//       Edited code comments.
//  09/25/2007 - J. Ritchie Carroll
//       Added TitleCase function to format a string with the first letter of each word capitalized.
//  04/16/2008 - Pinal C. Patel
//       Made the keys of the string dictionary returned by ParseKeyValuePairs function case-insensitive.
//       Added JoinKeyValuePairs overloads that does the exact opposite of ParseKeyValuePairs.
//  09/19/2008 - J. Ritchie Carroll
//       Converted to C# extensions.
//  12/13/2008 - F. Russell Roberson
//       Generalized ParseBoolean to include "Y", and "T".
//       Added IndexOfRepeatedChar - Returns the index of the first character that is repeated.
//       Added Reverse - Reverses the order of characters in a string.
//       Added EnsureEnd - Ensures that a string ends with a specified char or string.
//       Added EnsureStart - Ensures that a string begins with a specified char or string.
//       Added IsNumeric - Test to see if a string only includes characters that can be interpreted as a number.
//       Added TrimWithEllipsisMiddle - Adds an ellipsis in the middle of a string as it is reduced to a specified length.
//       Added TrimWithEllipsisEnd - Trims a string to not exceed a fixed length and adds a ellipsis to string end.
//  02/10/2009 - J. Ritchie Carroll
//       Added ConvertToType overloaded extensions.
//  02/17/2009 - Josh L. Patterson
//       Edited Code Comments.
//  09/14/2009 - Stephen C. Wills
//       Added new header and license agreement.
//  01/11/2010 - Galen K. Riley
//      Bug fixes for unit tests:
//      ConvertToType - Fix to throw ArgumentNullException instead of NullReferenceException for null value
//      ConvertToType - Handling failed conversions better. Calling ConvertToType<int>("\0") returns properly
//      JoinKeyValuePairs - Fix to throw ArgumentNullException instead of NullReferenceException
//      ReplaceCharacters - Fix to throw ArgumentNullException instead of NullReferenceException for null replacementCharacter
//      RemoveCharacters - Fix to throw ArgumentNullException instead of NullReferenceException for null characterTestFunction
//      ReplaceCrLfs - Fix to throw ArgumentNullException instead of NullReferenceException for null value
//      RegexDecode - Fix to throw ArgumentNullException instead of NullReferenceException for null value
//  12/03/2010 - J. Ritchie Carroll
//      Modifed ParseKeyValuePairs such that it could handle nested pairs to any needed depth.
//  12/05/2010 - Pinal C. Patel
//       Added an overload for ConvertToType() that takes CultureInfo as a parameter.
//  12/07/2010 - Pinal C. Patel
//       Updated ConvertToType() to return the type default if passed in string is null or empty.
//  01/04/2011 - J. Ritchie Carroll
//       Modified ConvertToType culture default to InvariantCulture for English style parsing defaults.
//  01/14/2011 - J. Ritchie Carroll
//       Modified JoinKeyValuePairs to delineate values that contain nested key/value pair expressions
//       such that the generated expression can correctly parsed.
//  03/23/2011 - J. Ritchie Carroll
//       Modified ParseKeyValuePairs to optionally ignore duplicate keys (default behavior now).
//       Removed overloads for ParseKeyValuePairs and JoinKeyValuePairs using optional parameters.
//  08/02/2011 - Pinal C. Patel
//       Added RemoveInvalidFileNameCharacters() and ReplaceInvalidFileNameCharacters() methods.
//
//*******************************************************************************************************

#region [ TVA Open Source Agreement ]
/*

 THIS OPEN SOURCE AGREEMENT ("AGREEMENT") DEFINES THE RIGHTS OF USE,REPRODUCTION, DISTRIBUTION,
 MODIFICATION AND REDISTRIBUTION OF CERTAIN COMPUTER SOFTWARE ORIGINALLY RELEASED BY THE
 TENNESSEE VALLEY AUTHORITY, A CORPORATE AGENCY AND INSTRUMENTALITY OF THE UNITED STATES GOVERNMENT
 ("GOVERNMENT AGENCY"). GOVERNMENT AGENCY IS AN INTENDED THIRD-PARTY BENEFICIARY OF ALL SUBSEQUENT
 DISTRIBUTIONS OR REDISTRIBUTIONS OF THE SUBJECT SOFTWARE. ANYONE WHO USES, REPRODUCES, DISTRIBUTES,
 MODIFIES OR REDISTRIBUTES THE SUBJECT SOFTWARE, AS DEFINED HEREIN, OR ANY PART THEREOF, IS, BY THAT
 ACTION, ACCEPTING IN FULL THE RESPONSIBILITIES AND OBLIGATIONS CONTAINED IN THIS AGREEMENT.

 Original Software Designation: openPDC
 Original Software Title: The TVA Open Source Phasor Data Concentrator
 User Registration Requested. Please Visit https://naspi.tva.com/Registration/
 Point of Contact for Original Software: J. Ritchie Carroll <mailto:jrcarrol@tva.gov>

 1. DEFINITIONS

 A. "Contributor" means Government Agency, as the developer of the Original Software, and any entity
 that makes a Modification.

 B. "Covered Patents" mean patent claims licensable by a Contributor that are necessarily infringed by
 the use or sale of its Modification alone or when combined with the Subject Software.

 C. "Display" means the showing of a copy of the Subject Software, either directly or by means of an
 image, or any other device.

 D. "Distribution" means conveyance or transfer of the Subject Software, regardless of means, to
 another.

 E. "Larger Work" means computer software that combines Subject Software, or portions thereof, with
 software separate from the Subject Software that is not governed by the terms of this Agreement.

 F. "Modification" means any alteration of, including addition to or deletion from, the substance or
 structure of either the Original Software or Subject Software, and includes derivative works, as that
 term is defined in the Copyright Statute, 17 USC § 101. However, the act of including Subject Software
 as part of a Larger Work does not in and of itself constitute a Modification.

 G. "Original Software" means the computer software first released under this Agreement by Government
 Agency entitled openPDC, including source code, object code and accompanying documentation, if any.

 H. "Recipient" means anyone who acquires the Subject Software under this Agreement, including all
 Contributors.

 I. "Redistribution" means Distribution of the Subject Software after a Modification has been made.

 J. "Reproduction" means the making of a counterpart, image or copy of the Subject Software.

 K. "Sale" means the exchange of the Subject Software for money or equivalent value.

 L. "Subject Software" means the Original Software, Modifications, or any respective parts thereof.

 M. "Use" means the application or employment of the Subject Software for any purpose.

 2. GRANT OF RIGHTS

 A. Under Non-Patent Rights: Subject to the terms and conditions of this Agreement, each Contributor,
 with respect to its own contribution to the Subject Software, hereby grants to each Recipient a
 non-exclusive, world-wide, royalty-free license to engage in the following activities pertaining to
 the Subject Software:

 1. Use

 2. Distribution

 3. Reproduction

 4. Modification

 5. Redistribution

 6. Display

 B. Under Patent Rights: Subject to the terms and conditions of this Agreement, each Contributor, with
 respect to its own contribution to the Subject Software, hereby grants to each Recipient under Covered
 Patents a non-exclusive, world-wide, royalty-free license to engage in the following activities
 pertaining to the Subject Software:

 1. Use

 2. Distribution

 3. Reproduction

 4. Sale

 5. Offer for Sale

 C. The rights granted under Paragraph B. also apply to the combination of a Contributor's Modification
 and the Subject Software if, at the time the Modification is added by the Contributor, the addition of
 such Modification causes the combination to be covered by the Covered Patents. It does not apply to
 any other combinations that include a Modification. 

 D. The rights granted in Paragraphs A. and B. allow the Recipient to sublicense those same rights.
 Such sublicense must be under the same terms and conditions of this Agreement.

 3. OBLIGATIONS OF RECIPIENT

 A. Distribution or Redistribution of the Subject Software must be made under this Agreement except for
 additions covered under paragraph 3H. 

 1. Whenever a Recipient distributes or redistributes the Subject Software, a copy of this Agreement
 must be included with each copy of the Subject Software; and

 2. If Recipient distributes or redistributes the Subject Software in any form other than source code,
 Recipient must also make the source code freely available, and must provide with each copy of the
 Subject Software information on how to obtain the source code in a reasonable manner on or through a
 medium customarily used for software exchange.

 B. Each Recipient must ensure that the following copyright notice appears prominently in the Subject
 Software:

          No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.

 C. Each Contributor must characterize its alteration of the Subject Software as a Modification and
 must identify itself as the originator of its Modification in a manner that reasonably allows
 subsequent Recipients to identify the originator of the Modification. In fulfillment of these
 requirements, Contributor must include a file (e.g., a change log file) that describes the alterations
 made and the date of the alterations, identifies Contributor as originator of the alterations, and
 consents to characterization of the alterations as a Modification, for example, by including a
 statement that the Modification is derived, directly or indirectly, from Original Software provided by
 Government Agency. Once consent is granted, it may not thereafter be revoked.

 D. A Contributor may add its own copyright notice to the Subject Software. Once a copyright notice has
 been added to the Subject Software, a Recipient may not remove it without the express permission of
 the Contributor who added the notice.

 E. A Recipient may not make any representation in the Subject Software or in any promotional,
 advertising or other material that may be construed as an endorsement by Government Agency or by any
 prior Recipient of any product or service provided by Recipient, or that may seek to obtain commercial
 advantage by the fact of Government Agency's or a prior Recipient's participation in this Agreement.

 F. In an effort to track usage and maintain accurate records of the Subject Software, each Recipient,
 upon receipt of the Subject Software, is requested to register with Government Agency by visiting the
 following website: https://naspi.tva.com/Registration/. Recipient's name and personal information
 shall be used for statistical purposes only. Once a Recipient makes a Modification available, it is
 requested that the Recipient inform Government Agency at the web site provided above how to access the
 Modification.

 G. Each Contributor represents that that its Modification does not violate any existing agreements,
 regulations, statutes or rules, and further that Contributor has sufficient rights to grant the rights
 conveyed by this Agreement.

 H. A Recipient may choose to offer, and to charge a fee for, warranty, support, indemnity and/or
 liability obligations to one or more other Recipients of the Subject Software. A Recipient may do so,
 however, only on its own behalf and not on behalf of Government Agency or any other Recipient. Such a
 Recipient must make it absolutely clear that any such warranty, support, indemnity and/or liability
 obligation is offered by that Recipient alone. Further, such Recipient agrees to indemnify Government
 Agency and every other Recipient for any liability incurred by them as a result of warranty, support,
 indemnity and/or liability offered by such Recipient.

 I. A Recipient may create a Larger Work by combining Subject Software with separate software not
 governed by the terms of this agreement and distribute the Larger Work as a single product. In such
 case, the Recipient must make sure Subject Software, or portions thereof, included in the Larger Work
 is subject to this Agreement.

 J. Notwithstanding any provisions contained herein, Recipient is hereby put on notice that export of
 any goods or technical data from the United States may require some form of export license from the
 U.S. Government. Failure to obtain necessary export licenses may result in criminal liability under
 U.S. laws. Government Agency neither represents that a license shall not be required nor that, if
 required, it shall be issued. Nothing granted herein provides any such export license.

 4. DISCLAIMER OF WARRANTIES AND LIABILITIES; WAIVER AND INDEMNIFICATION

 A. No Warranty: THE SUBJECT SOFTWARE IS PROVIDED "AS IS" WITHOUT ANY WARRANTY OF ANY KIND, EITHER
 EXPRESSED, IMPLIED, OR STATUTORY, INCLUDING, BUT NOT LIMITED TO, ANY WARRANTY THAT THE SUBJECT
 SOFTWARE WILL CONFORM TO SPECIFICATIONS, ANY IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
 PARTICULAR PURPOSE, OR FREEDOM FROM INFRINGEMENT, ANY WARRANTY THAT THE SUBJECT SOFTWARE WILL BE ERROR
 FREE, OR ANY WARRANTY THAT DOCUMENTATION, IF PROVIDED, WILL CONFORM TO THE SUBJECT SOFTWARE. THIS
 AGREEMENT DOES NOT, IN ANY MANNER, CONSTITUTE AN ENDORSEMENT BY GOVERNMENT AGENCY OR ANY PRIOR
 RECIPIENT OF ANY RESULTS, RESULTING DESIGNS, HARDWARE, SOFTWARE PRODUCTS OR ANY OTHER APPLICATIONS
 RESULTING FROM USE OF THE SUBJECT SOFTWARE. FURTHER, GOVERNMENT AGENCY DISCLAIMS ALL WARRANTIES AND
 LIABILITIES REGARDING THIRD-PARTY SOFTWARE, IF PRESENT IN THE ORIGINAL SOFTWARE, AND DISTRIBUTES IT
 "AS IS."

 B. Waiver and Indemnity: RECIPIENT AGREES TO WAIVE ANY AND ALL CLAIMS AGAINST GOVERNMENT AGENCY, ITS
 AGENTS, EMPLOYEES, CONTRACTORS AND SUBCONTRACTORS, AS WELL AS ANY PRIOR RECIPIENT. IF RECIPIENT'S USE
 OF THE SUBJECT SOFTWARE RESULTS IN ANY LIABILITIES, DEMANDS, DAMAGES, EXPENSES OR LOSSES ARISING FROM
 SUCH USE, INCLUDING ANY DAMAGES FROM PRODUCTS BASED ON, OR RESULTING FROM, RECIPIENT'S USE OF THE
 SUBJECT SOFTWARE, RECIPIENT SHALL INDEMNIFY AND HOLD HARMLESS  GOVERNMENT AGENCY, ITS AGENTS,
 EMPLOYEES, CONTRACTORS AND SUBCONTRACTORS, AS WELL AS ANY PRIOR RECIPIENT, TO THE EXTENT PERMITTED BY
 LAW.  THE FOREGOING RELEASE AND INDEMNIFICATION SHALL APPLY EVEN IF THE LIABILITIES, DEMANDS, DAMAGES,
 EXPENSES OR LOSSES ARE CAUSED, OCCASIONED, OR CONTRIBUTED TO BY THE NEGLIGENCE, SOLE OR CONCURRENT, OF
 GOVERNMENT AGENCY OR ANY PRIOR RECIPIENT.  RECIPIENT'S SOLE REMEDY FOR ANY SUCH MATTER SHALL BE THE
 IMMEDIATE, UNILATERAL TERMINATION OF THIS AGREEMENT.

 5. GENERAL TERMS

 A. Termination: This Agreement and the rights granted hereunder will terminate automatically if a
 Recipient fails to comply with these terms and conditions, and fails to cure such noncompliance within
 thirty (30) days of becoming aware of such noncompliance. Upon termination, a Recipient agrees to
 immediately cease use and distribution of the Subject Software. All sublicenses to the Subject
 Software properly granted by the breaching Recipient shall survive any such termination of this
 Agreement.

 B. Severability: If any provision of this Agreement is invalid or unenforceable under applicable law,
 it shall not affect the validity or enforceability of the remainder of the terms of this Agreement.

 C. Applicable Law: This Agreement shall be subject to United States federal law only for all purposes,
 including, but not limited to, determining the validity of this Agreement, the meaning of its
 provisions and the rights, obligations and remedies of the parties.

 D. Entire Understanding: This Agreement constitutes the entire understanding and agreement of the
 parties relating to release of the Subject Software and may not be superseded, modified or amended
 except by further written agreement duly executed by the parties.

 E. Binding Authority: By accepting and using the Subject Software under this Agreement, a Recipient
 affirms its authority to bind the Recipient to all terms and conditions of this Agreement and that
 Recipient hereby agrees to all terms and conditions herein.

 F. Point of Contact: Any Recipient contact with Government Agency is to be directed to the designated
 representative as follows: J. Ritchie Carroll <mailto:jrcarrol@tva.gov>.

*/
#endregion

#region [ Contributor License Agreements ]

//******************************************************************************************************
//
//  Copyright © 2011, Grid Protection Alliance.  All Rights Reserved.
//
//  The GPA licenses this file to you under the Eclipse Public License -v 1.0 (the "License"); you may
//  not use this file except in compliance with the License. You may obtain a copy of the License at:
//
//      http://www.opensource.org/licenses/eclipse-1.0.php
//
//  Unless agreed to in writing, the subject software distributed under the License is distributed on an
//  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
//  License for the specific language governing permissions and limitations.
//
//******************************************************************************************************

#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace TVA
{
    /// <summary>Defines extension functions related to string manipulation.</summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Parses a string intended to represent a boolean value.
        /// </summary>
        /// <param name="value">String representing a boolean value.</param>
        /// <returns>Parsed boolean value.</returns>
        /// <remarks>
        /// This function, unlike Boolean.Parse, correctly parses a boolean value, even if the string value
        /// specified is a number (e.g., 0 or -1). Boolean.Parse expects a string to be represented as
        /// "True" or "False" (i.e., Boolean.TrueString or Boolean.FalseString respectively).
        /// </remarks>
        public static bool ParseBoolean(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            value = value.Trim();

            if (value.Length > 0)
            {
                // Try to parse string a number
                int iresult;

                if (int.TryParse(value, out iresult))
                {
                    return (iresult != 0);
                }
                else
                {
                    // Try to parse string as a boolean
                    bool bresult;

                    if (bool.TryParse(value, out bresult))
                    {
                        return bresult;
                    }
                    else
                    {
                        char test = value.ToUpper()[0];
                        return (test == 'T' || test == 'Y' ? true : false);
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Converts this string into the specified type.
        /// </summary>
        /// <typeparam name="T"><see cref="Type"/> to convert string to.</typeparam>
        /// <param name="value">Source string to convert to type.</param>
        /// <returns><see cref="String"/> converted to specfied <see cref="Type"/>; default value of specified type T if conversion fails.</returns>
        /// <remarks>
        /// This function makes use of a <see cref="TypeConverter"/> to convert this <see cref="String"/> to the specified type T,
        /// the best way to make sure <paramref name="value"/> can be converted back to its original type is to use the same
        /// <see cref="TypeConverter"/> to convert the original object to a <see cref="String"/>; see the
        /// <see cref="Common.TypeConvertToString(object)"/> method for an easy way to do this.
        /// </remarks>
        public static T ConvertToType<T>(this string value)
        {
            return ConvertToType<T>(value, null);
        }

        /// <summary>
        /// Converts this string into the specified type.
        /// </summary>
        /// <typeparam name="T"><see cref="Type"/> to convert string to.</typeparam>
        /// <param name="value">Source string to convert to type.</param>
        /// <param name="type"><see cref="Type"/> to convert string to.</param>
        /// <returns><see cref="String"/> converted to specfied <see cref="Type"/>; default value of specified type T if conversion fails.</returns>
        /// <remarks>
        /// This function makes use of a <see cref="TypeConverter"/> to convert this <see cref="String"/> to the specified <paramref name="type"/>,
        /// the best way to make sure <paramref name="value"/> can be converted back to its original type is to use the same
        /// <see cref="TypeConverter"/> to convert the original object to a <see cref="String"/>; see the
        /// <see cref="Common.TypeConvertToString(object)"/> method for an easy way to do this.
        /// </remarks>
        public static T ConvertToType<T>(this string value, Type type)
        {
            return ConvertToType<T>(value, type, null);
        }

        /// <summary>
        /// Converts this string into the specified type.
        /// </summary>
        /// <typeparam name="T"><see cref="Type"/> to convert string to.</typeparam>
        /// <param name="value">Source string to convert to type.</param>
        /// <param name="type"><see cref="Type"/> to convert string to.</param>
        /// <param name="culture"><see cref="CultureInfo"/> to use for the conversion.</param>
        /// <returns><see cref="String"/> converted to specfied <see cref="Type"/>; default value of specified type T if conversion fails.</returns>
        /// <remarks>
        /// This function makes use of a <see cref="TypeConverter"/> to convert this <see cref="String"/> to the specified <paramref name="type"/>,
        /// the best way to make sure <paramref name="value"/> can be converted back to its original type is to use the same
        /// <see cref="TypeConverter"/> to convert the original object to a <see cref="String"/>; see the
        /// <see cref="Common.TypeConvertToString(object)"/> method for an easy way to do this.
        /// </remarks>
        public static T ConvertToType<T>(this string value, Type type, CultureInfo culture)
        {
            // Don't proceed further if string is empty.
            if (string.IsNullOrEmpty(value))
                return default(T);

            // Initialize return type if not specified.
            if ((object)type == null)
                type = typeof(T);

            // Initialize culture info if not specified.
            if ((object)culture == null)
                culture = CultureInfo.InvariantCulture;

            try
            {
                if (type.IsAssignableFrom(typeof(bool)))
                {
                    // Handle booleans as a special case to allow numeric entries as well as true/false
                    return (T)((object)value.ParseBoolean());
                }
                else
                {
                    if (type.IsAssignableFrom(typeof(IConvertible)))
                    {
                        // This is faster for native types than using type converter...
                        return (T)Convert.ChangeType(value, type, culture);
                    }
                    else
                    {
                        // Handle objects that have type converters (e.g., Enum, Color, Point, etc.)
                        TypeConverter converter = TypeDescriptor.GetConverter(type);
                        return (T)converter.ConvertFromString(null, culture, value);
                    }
                }
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// Turns source string into an array of string segements - each with a set maximum width - for parsing or displaying.
        /// </summary>
        /// <param name="value">Input string to break up into segements.</param>
        /// <param name="segmentSize">Maximum size of returned segment.</param>
        /// <returns>Array of string segments as parsed from source string.</returns>
        /// <remarks>Returns a single element array with an empty string if source string is null or empty.</remarks>
        public static string[] GetSegments(this string value, int segmentSize)
        {
            if (segmentSize <= 0)
                throw new ArgumentOutOfRangeException("segmentSize", "segmentSize must be greater than zero.");

            if (string.IsNullOrEmpty(value))
                return new string[] { "" };

            int totalSegments = (int)Math.Ceiling(value.Length / (double)segmentSize);
            string[] segments = new string[totalSegments];

            for (int x = 0; x < segments.Length; x++)
            {
                if (x * segmentSize + segmentSize >= value.Length)
                    segments[x] = value.Substring(x * segmentSize);
                else
                    segments[x] = value.Substring(x * segmentSize, segmentSize);
            }

            return segments;
        }

        /// <summary>
        /// Combines a dictionary of key-value pairs in to a string.
        /// </summary>
        /// <param name="pairs">Dictionary of key-value pairs.</param>
        /// <param name="parameterDelimeter">Character that delimits one key-value pair from another (eg. ';').</param>
        /// <param name="keyValueDelimeter">Character that delimits a key from its value (eg. '=').</param>
        /// <param name="startValueDelimeter">Optional character that marks the start of a value such that value could contain other
        /// <paramref name="parameterDelimeter"/> or <paramref name="keyValueDelimeter"/> characters (e.g., "{").</param>
        /// <param name="endValueDelimeter">Optional character that marks the end of a value such that value could contain other
        /// <paramref name="parameterDelimeter"/> or <paramref name="keyValueDelimeter"/> characters (e.g., "}").</param>
        /// <returns>A string of key-value pairs.</returns>
        /// <remarks>
        /// Values will be escaped within <paramref name="startValueDelimeter"/> and <paramref name="endValueDelimeter"/>
        /// to contain nested key/value pair expressions like the following: <c>normalKVP=-1; nestedKVP={p1=true; p2=0.001}</c>,
        /// when either the <paramref name="parameterDelimeter"/> or <paramref name="keyValueDelimeter"/> are detected in the
        /// value of the key/value pair.
        /// </remarks>
        public static string JoinKeyValuePairs(this Dictionary<string, string> pairs, char parameterDelimeter = ';', char keyValueDelimeter = '=', char startValueDelimeter = '{', char endValueDelimeter = '}')
        {
            // <pex>
            if ((object)pairs == null)
                throw new ArgumentNullException("pairs");
            // </pex>

            char[] delimiters = { parameterDelimeter, keyValueDelimeter };
            StringBuilder result = new StringBuilder();
            string value;

            foreach (string key in pairs.Keys)
            {
                value = pairs[key];

                if (value.IndexOfAny(delimiters) >= 0)
                    value = startValueDelimeter + value + endValueDelimeter;

                result.AppendFormat("{0}{1}{2}{3}", key, keyValueDelimeter, value, parameterDelimeter);
            }

            return result.ToString();
        }

        /// <summary>
        /// Parses key/value pair expressions from a string. Parameter pairs are delimited by <paramref name="keyValueDelimeter"/>
        /// and multiple pairs separated by <paramref name="parameterDelimeter"/>. Supports encapsulated nested expressions.
        /// </summary>
        /// <param name="value">String containing key/value pair expressions to parse.</param>
        /// <param name="parameterDelimeter">Character that delimits one key/value pair from another.</param>
        /// <param name="keyValueDelimeter">Character that delimits key from value.</param>
        /// <param name="startValueDelimeter">Optional character that marks the start of a value such that value could contain other
        /// <paramref name="parameterDelimeter"/> or <paramref name="keyValueDelimeter"/> characters.</param>
        /// <param name="endValueDelimeter">Optional character that marks the end of a value such that value could contain other
        /// <paramref name="parameterDelimeter"/> or <paramref name="keyValueDelimeter"/> characters.</param>
        /// <param name="ignoreDuplicateKeys">Flag determines whether duplicates are ignored. If flag is set to <c>false</c> an
        /// <see cref="ArgumentException"/> will be thrown when all key parameters are not unique.</param>
        /// <returns>Dictionary of key/value pairs.</returns>
        /// <remarks>
        /// <para>
        /// Parses a string containing key/value pair expressions (e.g., "localPort=5001; transportProtocol=UDP; interface=0.0.0.0").
        /// This method treats all "keys" as case-insensitive. Nesting of key/value pair expressions is allowed by encapsulating the
        /// value using the <paramref name="startValueDelimeter"/> and <paramref name="endValueDelimeter"/> values (e.g., 
        /// "dataChannel={Port=-1;Clients=localhost:8800}; commandChannel={Port=8900}; dataFormat=FloatingPoint;"). There must be one
        /// <paramref name="endValueDelimeter"/> for each encountered <paramref name="startValueDelimeter"/> in the value or a
        /// <see cref="FormatException"/> will be thrown. Multiple levels of nesting is supported. If the <paramref name="ignoreDuplicateKeys"/>
        /// flag is set to <c>false</c> an <see cref="ArgumentException"/> will be thrown when all key parameters are not unique. Note
        /// that keys within nested expressions are considered separate key/value pair strings and are not considered when checking
        /// for duplicate keys.
        /// </para>
        /// </remarks>
        /// <exception cref="ArgumentNullException">value is null.</exception>
        /// <exception cref="ArgumentException">All delimeters must be unique -or- all keys must be unique when
        /// <paramref name="ignoreDuplicateKeys"/> is set to <c>false</c>.</exception>
        /// <exception cref="FormatException">Total nested key/value value pair expressions are mismatched -or- encountered
        /// <paramref name="endValueDelimeter"/> before <paramref name="startValueDelimeter"/>.</exception>
        public static Dictionary<string, string> ParseKeyValuePairs(this string value, char parameterDelimeter = ';', char keyValueDelimeter = '=', char startValueDelimeter = '{', char endValueDelimeter = '}', bool ignoreDuplicateKeys = true)
        {
            if (value == (string)null)
                throw new ArgumentNullException("value");

            if (parameterDelimeter == keyValueDelimeter ||
                parameterDelimeter == startValueDelimeter ||
                parameterDelimeter == endValueDelimeter ||
                keyValueDelimeter == startValueDelimeter ||
                keyValueDelimeter == endValueDelimeter ||
                startValueDelimeter == endValueDelimeter)
                throw new ArgumentException("All delimeters must be unique");

            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
            StringBuilder escapedValue = new StringBuilder();
            string escapedParameterDelimeter = parameterDelimeter.RegexEncode();
            string escapedKeyValueDelimeter = keyValueDelimeter.RegexEncode();
            string escapedStartValueDelimeter = startValueDelimeter.RegexEncode();
            string escapedEndValueDelimeter = endValueDelimeter.RegexEncode();
            string[] elements;
            string key, unescapedValue;
            bool valueEscaped = false;
            int delimeterDepth = 0;
            char character;

            // Escape any parameter or key/value delimeters within tagged value sequences
            //      For example, the following string:
            //          "normalKVP=-1; nestedKVP={p1=true; p2=false}")
            //      would be encoded as:
            //          "normalKVP=-1; nestedKVP=p1\\u003dtrue\\u003b p2\\u003dfalse")
            for (int x = 0; x < value.Length; x++)
            {
                character = value[x];

                if (character == startValueDelimeter)
                {
                    if (!valueEscaped)
                    {
                        valueEscaped = true;
                        continue;   // Don't add tag start delimeter to final value
                    }
                    else
                    {
                        // Handle nested delimeters
                        delimeterDepth++;
                    }
                }

                if (character == endValueDelimeter)
                {
                    if (valueEscaped)
                    {
                        if (delimeterDepth > 0)
                        {
                            // Handle nested delimeters
                            delimeterDepth--;
                        }
                        else
                        {
                            valueEscaped = false;
                            continue;   // Don't add tag stop delimeter to final value
                        }
                    }
                    else
                    {
                        throw new FormatException(string.Format("Failed to parse key/value pairs: invalid delimeter mismatch. Encountered end value delimeter \'{0}\' before start value delimeter \'{1}\'.", endValueDelimeter, startValueDelimeter));
                    }
                }

                if (valueEscaped)
                {
                    // Escape any delimeter characters inside nested key/value pair
                    if (character == parameterDelimeter)
                        escapedValue.Append(escapedParameterDelimeter);
                    else if (character == keyValueDelimeter)
                        escapedValue.Append(escapedKeyValueDelimeter);
                    else if (character == startValueDelimeter)
                        escapedValue.Append(escapedStartValueDelimeter);
                    else if (character == endValueDelimeter)
                        escapedValue.Append(escapedEndValueDelimeter);
                    else
                        escapedValue.Append(character);
                }
                else
                {
                    escapedValue.Append(character);
                }
            }

            if (delimeterDepth != 0 || valueEscaped)
            {
                // If value is still escaped, tagged expression was not terminated
                if (valueEscaped)
                    delimeterDepth = 1;

                throw new FormatException(string.Format("Failed to parse key/value pairs: invalid delimeter mismatch. Encountered more {0} than {1}.", delimeterDepth > 0 ? "start value delimeters \'" + startValueDelimeter + "\'" : "end value delimeters \'" + endValueDelimeter + "\'", delimeterDepth < 0 ? "start value delimeters \'" + startValueDelimeter + "\'" : "end value delimeters \'" + endValueDelimeter + "\'"));
            }

            // Parse key/value pairs from escaped value
            foreach (string parameter in escapedValue.ToString().Split(parameterDelimeter))
            {
                // Parse out parameter's key/value elements
                elements = parameter.Split(keyValueDelimeter);

                if (elements.Length == 2)
                {
                    // Get key expression
                    key = elements[0].ToString().Trim();

                    // Get unescaped value expression
                    unescapedValue = elements[1].ToString().Trim().
                        Replace(escapedParameterDelimeter, parameterDelimeter.ToString()).
                        Replace(escapedKeyValueDelimeter, keyValueDelimeter.ToString()).
                        Replace(escapedStartValueDelimeter, startValueDelimeter.ToString()).
                        Replace(escapedEndValueDelimeter, endValueDelimeter.ToString());

                    // Add key/value pair to dictionary
                    if (ignoreDuplicateKeys)
                    {
                        // Add or replace key elements with unescaped value
                        keyValuePairs[key] = unescapedValue;
                    }
                    else
                    {
                        // Add key elements with unescaped value throwing an exception for encountered duplicate keys
                        if (keyValuePairs.ContainsKey(key))
                            throw new ArgumentException(string.Format("Failed to parse key/value pairs: duplicate key encountered. Key \"{0}\" is not unique within the string: \"{1}\"", key, value));

                        keyValuePairs.Add(key, unescapedValue);
                    }
                }
            }

            return keyValuePairs;
        }

        /// <summary>
        /// Ensures parameter is not an empty or null string. Returns a single space if test value is empty.
        /// </summary>
        /// <param name="testValue">Value to test for null or empty.</param>
        /// <returns>A non-empty string.</returns>
        public static string NotEmpty(this string testValue)
        {
            return testValue.NotEmpty(" ");
        }

        /// <summary>
        /// Ensures parameter is not an empty or null string.
        /// </summary>
        /// <param name="testValue">Value to test for null or empty.</param>
        /// <param name="nonEmptyReturnValue">Value to return if <paramref name="testValue">testValue</paramref> is null or empty.</param>
        /// <returns>A non-empty string.</returns>
        public static string NotEmpty(this string testValue, string nonEmptyReturnValue)
        {
            if (string.IsNullOrEmpty(nonEmptyReturnValue))
                throw new ArgumentException("nonEmptyReturnValue cannot be null or empty");

            if (string.IsNullOrEmpty(testValue))
                return nonEmptyReturnValue;
            else
                return testValue;
        }

        /// <summary>
        /// Replaces all characters passing delegate test with specified replacement character.
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <param name="replacementCharacter">Character used to replace characters passing delegate test.</param>
        /// <param name="characterTestFunction">Delegate used to determine whether or not character should be replaced.</param>
        /// <returns>Returns <paramref name="value" /> with all characters passing delegate test replaced.</returns>
        /// <remarks>Allows you to specify a replacement character (e.g., you may want to use a non-breaking space: Convert.ToChar(160)).</remarks>
        public static string ReplaceCharacters(this string value, char replacementCharacter, Func<char, bool> characterTestFunction)
        {
            // <pex>
            if (characterTestFunction == (Func<char, bool>)null)
                throw new ArgumentNullException("characterTestFunction");
            // </pex>
            if (string.IsNullOrEmpty(value))
                return "";

            StringBuilder result = new StringBuilder();
            char character;

            for (int x = 0; x < value.Length; x++)
            {
                character = value[x];

                if (characterTestFunction(character))
                    result.Append(replacementCharacter);
                else
                    result.Append(character);
            }

            return result.ToString();
        }

        /// <summary>
        /// Removes all characters passing delegate test from a string.
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <param name="characterTestFunction">Delegate used to determine whether or not character should be removed.</param>
        /// <returns>Returns <paramref name="value" /> with all characters passing delegate test removed.</returns>
        public static string RemoveCharacters(this string value, Func<char, bool> characterTestFunction)
        {
            // <pex>
            if (characterTestFunction == (Func<char, bool>)null)
                throw new ArgumentNullException("characterTestFunction");
            // </pex>
            if (string.IsNullOrEmpty(value))
                return "";

            StringBuilder result = new StringBuilder();
            char character;

            for (int x = 0; x < value.Length; x++)
            {
                character = value[x];

                if (!characterTestFunction(character))
                    result.Append(character);
            }

            return result.ToString();
        }

        /// <summary>
        /// Removes all white space (as defined by IsWhiteSpace) from a string.
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <returns>Returns <paramref name="value" /> with all white space removed.</returns>
        public static string RemoveWhiteSpace(this string value)
        {
            return value.RemoveCharacters(char.IsWhiteSpace);
        }

        /// <summary>
        /// Replaces all white space characters (as defined by IsWhiteSpace) with specified replacement character.
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <param name="replacementCharacter">Character used to "replace" white space characters.</param>
        /// <returns>Returns <paramref name="value" /> with all white space characters replaced.</returns>
        /// <remarks>Allows you to specify a replacement character (e.g., you may want to use a non-breaking space: Convert.ToChar(160)).</remarks>
        public static string ReplaceWhiteSpace(this string value, char replacementCharacter)
        {
            return value.ReplaceCharacters(replacementCharacter, char.IsWhiteSpace);
        }

        /// <summary>
        /// Removes all control characters from a string.
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <returns>Returns <paramref name="value" /> with all control characters removed.</returns>
        public static string RemoveControlCharacters(this string value)
        {
            return value.RemoveCharacters(char.IsControl);
        }

        /// <summary>
        /// Replaces all control characters in a string with a single space.
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <returns>Returns <paramref name="value" /> with all control characters replaced as a single space.</returns>
        public static string ReplaceControlCharacters(this string value)
        {
            return value.ReplaceControlCharacters(' ');
        }

        /// <summary>
        /// Replaces all control characters in a string with specified replacement character.
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <param name="replacementCharacter">Character used to "replace" control characters.</param>
        /// <returns>Returns <paramref name="value" /> with all control characters replaced.</returns>
        /// <remarks>Allows you to specify a replacement character (e.g., you may want to use a non-breaking space: Convert.ToChar(160)).</remarks>
        public static string ReplaceControlCharacters(this string value, char replacementCharacter)
        {
            return value.ReplaceCharacters(replacementCharacter, char.IsControl);
        }

        /// <summary>
        /// Removes all carriage returns and line feeds from a string.
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <returns>Returns <paramref name="value" /> with all CR and LF characters removed.</returns>
        public static string RemoveCrLfs(this string value)
        {
            return value.RemoveCharacters(c => c == '\r' || c == '\n');
        }

        /// <summary>
        /// Replaces all carriage return and line feed characters (as well as CR/LF sequences) in a string with specified replacement character.
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <param name="replacementCharacter">Character used to "replace" CR and LF characters.</param>
        /// <returns>Returns <paramref name="value" /> with all CR and LF characters replaced.</returns>
        /// <remarks>Allows you to specify a replacement character (e.g., you may want to use a non-breaking space: Convert.ToChar(160)).</remarks>
        public static string ReplaceCrLfs(this string value, char replacementCharacter)
        {
            // <pex>
            if (value == (string)null)
                throw new ArgumentNullException("value");
            // </pex>
            return value.Replace(Environment.NewLine, replacementCharacter.ToString()).ReplaceCharacters(replacementCharacter, c => c == '\r' || c == '\n');
        }

        /// <summary>
        /// Removes duplicate character strings (adjoining replication) in a string.
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <param name="duplicatedValue">String whose duplicates are to be removed.</param>
        /// <returns>Returns <paramref name="value" /> with all duplicated <paramref name="duplicatedValue" /> removed.</returns>
        public static string RemoveDuplicates(this string value, string duplicatedValue)
        {
            if (string.IsNullOrEmpty(value))
                return "";
            if (string.IsNullOrEmpty(duplicatedValue))
                return value;

            string duplicate = duplicatedValue + duplicatedValue;

            while (value.IndexOf(duplicate) > -1)
            {
                value = value.Replace(duplicate, duplicatedValue);
            }

            return value;
        }

        /// <summary>
        /// Removes the terminator ('\0') from a null terminated string.
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <returns>Returns <paramref name="value" /> with all characters to the left of the terminator.</returns>
        public static string RemoveNull(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            int nullPos = value.IndexOf('\0');

            if (nullPos > -1)
                return value.Substring(0, nullPos);
            else
                return value;
        }

        /// <summary>
        /// Replaces all repeating white space with a single space.
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <returns>Returns <paramref name="value" /> with all duplicate white space removed.</returns>
        public static string RemoveDuplicateWhiteSpace(this string value)
        {
            return value.RemoveDuplicateWhiteSpace(' ');
        }

        /// <summary>
        /// Replaces all repeating white space with specified spacing character.
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <param name="spacingCharacter">Character value to use to insert as single white space value.</param>
        /// <returns>Returns <paramref name="value" /> with all duplicate white space removed.</returns>
        /// <remarks>This function allows you to specify spacing character (e.g., you may want to use a non-breaking space: <c>Convert.ToChar(160)</c>).</remarks>
        public static string RemoveDuplicateWhiteSpace(this string value, char spacingCharacter)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            StringBuilder result = new StringBuilder();
            bool lastCharWasSpace = false;
            char character;

            for (int x = 0; x < value.Length; x++)
            {
                character = value[x];

                if (char.IsWhiteSpace(character))
                {
                    lastCharWasSpace = true;
                }
                else
                {
                    if (lastCharWasSpace)
                        result.Append(spacingCharacter);

                    result.Append(character);
                    lastCharWasSpace = false;
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Removes all invalid file name characters (\ / : * ? " &lt; &gt; |) from a string.
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <returns>Returns <paramref name="value" /> with all invalid file name characters removed.</returns>
        public static string RemoveInvalidFileNameCharacters(this string value)
        {
            return value.RemoveCharacters(c => Array.IndexOf(Path.GetInvalidFileNameChars(), c) >= 0);
        }

        /// <summary>
        /// Replaces all invalid file name characters (\ / : * ? " &lt; &gt; |) in a string with the specified <paramref name="replacementCharacter"/>.
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <param name="replacementCharacter">Character used to replace the invalid characters.</param>
        /// <returns>>Returns <paramref name="value" /> with all invalid file name characters replaced.</returns>
        public static string ReplaceInvalidFileNameCharacters(this string value, char replacementCharacter)
        {
            return value.ReplaceCharacters(replacementCharacter, c => Array.IndexOf(Path.GetInvalidFileNameChars(), c) >= 0);
        }

        /// <summary>
        /// Counts the total number of the occurances of a character in the given string.
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <param name="characterToCount">Character to be counted.</param>
        /// <returns>Total number of the occurances of <paramref name="characterToCount" /> in the given string.</returns>
        public static int CharCount(this string value, char characterToCount)
        {
            if (string.IsNullOrEmpty(value))
                return 0;

            int total = 0;

            for (int x = 0; x < value.Length; x++)
            {
                if (value[x] == characterToCount)
                    total++;
            }

            return total;
        }

        /// <summary>
        /// Tests to see if a string is contains only digits based on Char.IsDigit function.
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <returns>True, if all string's characters are digits; otherwise, false.</returns>
        /// <seealso cref="char.IsDigit(char)"/>
        public static bool IsAllDigits(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            value = value.Trim();
            if (value.Length == 0)
                return false;

            for (int x = 0; x < value.Length; x++)
            {
                if (!char.IsDigit(value[x]))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Tests to see if a string contains only numbers based on Char.IsNumber function.
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <returns>True, if all string's characters are numbers; otherwise, false.</returns>
        /// <seealso cref="char.IsNumber(char)"/>
        public static bool IsAllNumbers(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            value = value.Trim();
            if (value.Length == 0)
                return false;

            for (int x = 0; x < value.Length; x++)
            {
                if (!char.IsNumber(value[x]))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Tests to see if a string's letters are all upper case.
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <returns>True, if all string's letter characters are upper case; otherwise, false.</returns>
        public static bool IsAllUpper(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            value = value.Trim();
            if (value.Length == 0)
                return false;

            for (int x = 0; x < value.Length; x++)
            {
                if (char.IsLetter(value[x]) && !char.IsUpper(value[x]))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Tests to see if a string's letters are all lower case.
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <returns>True, if all string's letter characters are lower case; otherwise, false.</returns>
        public static bool IsAllLower(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            value = value.Trim();
            if (value.Length == 0)
                return false;

            for (int x = 0; x < value.Length; x++)
            {
                if (char.IsLetter(value[x]) && !char.IsLower(value[x]))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Tests to see if a string contains only letters.
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <returns>True, if all string's characters are letters; otherwise, false.</returns>
        /// <remarks>Any non-letter character (e.g., punctuation marks) causes this function to return false (See overload to ignore punctuation
        /// marks.).</remarks>
        public static bool IsAllLetters(this string value)
        {
            return value.IsAllLetters(false);
        }

        /// <summary>
        /// Tests to see if a string contains only letters.
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <param name="ignorePunctuation">Set to True to ignore punctuation.</param>
        /// <returns>True, if all string's characters are letters; otherwise, false.</returns>
        public static bool IsAllLetters(this string value, bool ignorePunctuation)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            value = value.Trim();
            if (value.Length == 0)
                return false;

            for (int x = 0; x < value.Length; x++)
            {
                if (ignorePunctuation)
                {
                    if (!(char.IsLetter(value[x]) || char.IsPunctuation(value[x])))
                        return false;
                }
                else
                {
                    if (!char.IsLetter(value[x]))
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Tests to see if a string contains only letters or digits.
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <returns>True, if all string's characters are either letters or digits; otherwise, false.</returns>
        /// <remarks>Any non-letter, non-digit character (e.g., punctuation marks) causes this function to return false (See overload to ignore
        /// punctuation marks.).</remarks>
        public static bool IsAllLettersOrDigits(this string value)
        {
            return value.IsAllLettersOrDigits(false);
        }

        /// <summary>
        /// Tests to see if a string contains only letters or digits.
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <param name="ignorePunctuation">Set to True to ignore punctuation.</param>
        /// <returns>True, if all string's characters are letters or digits; otherwise, false.</returns>
        public static bool IsAllLettersOrDigits(this string value, bool ignorePunctuation)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            value = value.Trim();
            if (value.Length == 0)
                return false;

            for (int x = 0; x < value.Length; x++)
            {
                if (ignorePunctuation)
                {
                    if (!(char.IsLetterOrDigit(value[x]) || char.IsPunctuation(value[x])))
                        return false;
                }
                else
                {
                    if (!char.IsLetterOrDigit(value[x]))
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Decodes the specified Regular Expression character back into a standard Unicode character.
        /// </summary>
        /// <param name="value">Regular Expression character to decode back into a Unicode character.</param>
        /// <returns>Standard Unicode character representation of specified Regular Expression character.</returns>
        public static char RegexDecode(this string value)
        {
            // <pex>
            if (value == (string)null)
                throw new ArgumentNullException("value");
            // </pex>
            return Convert.ToChar(Convert.ToUInt16(value.Replace("\\u", "0x"), 16));
        }

        /// <summary>
        /// Encodes a string into a base-64 string.
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <remarks>
        /// <para>Performs a base-64 style of string encoding useful for data obfuscation or safe XML data string transmission.</para>
        /// <para>Note: This function encodes a "String". Use the Convert.ToBase64String function to encode a binary data buffer.</para>
        /// </remarks>
        /// <returns>A <see cref="String"></see> value representing the encoded input of <paramref name="value"/>.</returns>
        public static string Base64Encode(this string value)
        {
            return Convert.ToBase64String(Encoding.Unicode.GetBytes(value));
        }

        /// <summary>
        /// Decodes a given base-64 encoded string encoded with <see cref="Base64Encode" />.
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <remarks>Note: This function decodes value back into a "String". Use the Convert.FromBase64String function to decode a base-64 encoded
        /// string back into a binary data buffer.</remarks>
        /// <returns>A <see cref="String"></see> value representing the decoded input of <paramref name="value"/>.</returns>
        public static string Base64Decode(this string value)
        {
            return Encoding.Unicode.GetString(Convert.FromBase64String(value));
        }

        /// <summary>
        /// Converts the provided string into title case (upper case first letter of each word).
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <remarks>Note: This function performs "ToLower" in input string then applies TextInfo.ToTitleCase for CurrentCulture. This way, even
        /// strings formatted in all-caps will still be properly formatted.</remarks>
        /// <returns>A <see cref="String"/> that has the first letter of each word capitalized.</returns>
        public static string ToTitleCase(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
        }

        /// <summary>
        /// Truncates the provided string from the left if it is longer that specified length.
        /// </summary>
        /// <param name="value">A <see cref="String"/> value that is to be truncated.</param>
        /// <param name="maxLength">The maximum number of characters that <paramref name="value"/> can be.</param>
        /// <returns>A <see cref="String"/> that is the truncated version of the <paramref name="value"/> string.</returns>
        public static string TruncateLeft(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            if (value.Length > maxLength)
                return value.Substring(value.Length - maxLength);

            return value;
        }

        /// <summary>
        /// Truncates the provided string from the right if it is longer that specified length.
        /// </summary>
        /// <param name="value">A <see cref="String"/> value that is to be truncated.</param>
        /// <param name="maxLength">The maximum number of characters that <paramref name="value"/> can be.</param>
        /// <returns>A <see cref="String"/> that is the truncated version of the <paramref name="value"/> string.</returns>
        public static string TruncateRight(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            if (value.Length > maxLength)
                return value.Substring(0, maxLength);

            return value;
        }

        /// <summary>
        /// Centers text within the specified maximum length, biased to the left.
        /// Text will be padded to the left and right with spaces.
        /// If value is greater than specified maximum length, value returned will be truncated from the right.
        /// </summary>
        /// <remarks>
        /// Handles multiple lines of text separated by Environment.NewLine.
        /// </remarks>
        /// <param name="value">A <see cref="String"/> to be centered.</param>
        /// <param name="maxLength">An <see cref="Int32"/> that is the maximum length of padding.</param>
        /// <returns>The centered string value.</returns>
        public static string CenterText(this string value, int maxLength)
        {
            return value.CenterText(maxLength, ' ');
        }

        /// <summary>
        /// Centers text within the specified maximum length, biased to the left.
        /// Text will be padded to the left and right with specified padding character.
        /// If value is greater than specified maximum length, value returned will be truncated from the right.
        /// </summary>
        /// <remarks>
        /// Handles multiple lines of text separated by <c>Environment.NewLine</c>.
        /// </remarks>
        /// <param name="value">A <see cref="String"/> to be centered.</param>
        /// <param name="maxLength">An <see cref="Int32"/> that is the maximum length of padding.</param>
        /// <param name="paddingCharacter">The <see cref="char"/> value to pad with.</param>
        /// <returns>The centered string value.</returns>
        public static string CenterText(this string value, int maxLength, char paddingCharacter)
        {
            if ((object)value == null)
                value = "";

            // If the text to be centered contains multiple lines, centers all the lines individually.
            StringBuilder result = new StringBuilder();
            string[] lines = value.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            string line;
            int lastLineIndex = lines.Length - 1; //(lines.Length != 0 && lines[lines.Length - 1].Trim() == string.Empty ? lines.Length - 2 : lines.Length - 1);

            for (int i = 0; i <= lastLineIndex; i++)
            {
                // Gets current line.
                line = lines[i];

                // Skips the last empty line as a result of split if original text had multiple lines.
                if (i == lastLineIndex && line.Trim().Length == 0)
                    continue;

                if (line.Length >= maxLength)
                {
                    // Truncates excess characters on the right.
                    result.Append(line.Substring(0, maxLength));
                }
                else
                {
                    int remainingSpace = maxLength - line.Length;
                    int leftSpaces;
                    int rightSpaces;

                    // Splits remaining space between the left and the right.
                    leftSpaces = remainingSpace / 2;
                    rightSpaces = leftSpaces;

                    // Adds any remaining odd space to the right (bias text to the left).
                    if (remainingSpace % 2 > 0)
                        rightSpaces++;

                    result.Append(new string(paddingCharacter, leftSpaces));
                    result.Append(line);
                    result.Append(new string(paddingCharacter, rightSpaces));
                }

                // Creates a new line only if the original text contains multiple lines.
                if (i < lastLineIndex)
                    result.AppendLine();
            }

            return result.ToString();
        }
        /// <summary>
        /// Performs a case insensitive string replacement.
        /// </summary>
        /// <param name="value">The string to examine.</param>
        /// <param name="fromText">The value to replace.</param>
        /// <param name="toText">The new value to be inserted</param>
        /// <returns>A string with replacements.</returns>
        public static string ReplaceCaseInsensitive(this string value, string fromText, string toText)
        {
            return (new Regex(fromText, RegexOptions.IgnoreCase | RegexOptions.Multiline)).Replace(value, toText);
        }

        /// <summary>
        /// Ensures a string starts with a specific character.
        /// </summary>
        /// <param name="value">Input string to process.</param>
        /// <param name="startChar">The character desired at string start.</param>
        /// <returns>The sent string with character at the start.</returns>
        public static string EnsureStart(this string value, char startChar)
        {
            return EnsureStart(value, startChar, false);
        }

        /// <summary>
        /// Ensures a string starts with a specific character.
        /// </summary>
        /// <param name="value">Input string to process.</param>
        /// <param name="startChar">The character desired at string start.</param>
        /// <param name="removeRepeatingChar">Set to <c>true</c> to ensure one and only one instance of <paramref name="startChar"/>.</param>
        /// <returns>The sent string with character at the start.</returns>
        public static string EnsureStart(this string value, char startChar, bool removeRepeatingChar)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            if (startChar == 0)
                return value;

            if (value[0] == startChar)
            {
                if (removeRepeatingChar)
                    return value.Substring(LastIndexOfRepeatedChar(value, startChar, 0));
                return value;
            }
            else
                return string.Concat(startChar, value);
        }

        /// <summary>
        /// Ensures a string starts with a specific string.
        /// </summary>
        /// <param name="value">Input string to process.</param>
        /// <param name="startString">The string desired at string start.</param>
        /// <returns>The sent string with string at the start.</returns>
        public static string EnsureStart(this string value, string startString)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            if (string.IsNullOrEmpty(startString))
                return value;

            if (value.IndexOf(startString) == 0)
                return value;
            else
                return string.Concat(startString, value);
        }

        /// <summary>
        /// Ensures a string ends with a specific character.
        /// </summary>
        /// <param name="value">Input string to process.</param>
        /// <param name="endChar">The character desired at string's end.</param>
        /// <returns>The sent string with character at the end.</returns>
        public static string EnsureEnd(this string value, char endChar)
        {
            return EnsureEnd(value, endChar, false);
        }

        /// <summary>
        /// Ensures a string ends with a specific character.
        /// </summary>
        /// <param name="value">Input string to process.</param>
        /// <param name="endChar">The character desired at string's end.</param>
        /// <param name="removeRepeatingChar">Set to <c>true</c> to ensure one and only one instance of <paramref name="endChar"/>.</param>
        /// <returns>The sent string with character at the end.</returns>
        public static string EnsureEnd(this string value, char endChar, bool removeRepeatingChar)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            if (endChar == 0)
                return value;

            if (value[value.Length - 1] == endChar)
            {
                if (removeRepeatingChar)
                {
                    int i = LastIndexOfRepeatedChar(value.Reverse(), endChar, 0);
                    return value.Substring(0, value.Length - i);
                }
                return value;
            }
            else
                return string.Concat(value, endChar);
        }

        /// <summary>
        /// Ensures a string ends with a specific string.
        /// </summary>
        /// <param name="value">Input string to process.</param>
        /// <param name="endString">The string desired at string's end.</param>
        /// <returns>The sent string with string at the end.</returns>
        public static string EnsureEnd(this string value, string endString)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            if (string.IsNullOrEmpty(endString))
                return value;

            if (value.EndsWith(endString))
                return value;
            else
                return string.Concat(value, endString);
        }

        /// <summary>
        /// Reverses the order of the characters in a string.
        /// </summary>
        /// <param name="value">Input string to process.</param>
        /// <returns>The reversed string.</returns>
        public static string Reverse(this string value)
        {
            // Experimented with several approaches.  This is the fastest.
            // Replaced original code that yielded 1.5% performance increase.
            // This code is faster than Array.Reverse.

            if (string.IsNullOrEmpty(value))
                return "";

            char[] arrChar = value.ToCharArray();
            char temp;
            int arrLength = arrChar.Length;
            int j;

            // Works for odd and even length strings since middle char is not swapped for an odd length string
            for (int i = 0; i < arrLength / 2; i++)
            {
                j = arrLength - i - 1;
                temp = arrChar[i];
                arrChar[i] = arrChar[j];
                arrChar[j] = temp;
            }

            return new string(arrChar);
        }

        /// <summary>
        /// Searches a string for a repeated instance of the specified <paramref name="characterToFind"/> from specified <paramref name="startIndex"/>.
        /// </summary>
        /// <param name="value">The string to process.</param>
        /// <param name="characterToFind">The character of interest.</param>
        /// <param name="startIndex">The index from which to begin the search.</param>
        /// <returns>The index of the first instance of the character that is repeated or (-1) if no repeated chars found.</returns>
        public static int IndexOfRepeatedChar(this string value, char characterToFind, int startIndex)
        {
            if (string.IsNullOrEmpty(value))
                return -1;

            if (startIndex < 0)
                return -1;

            if (characterToFind == 0)
                return -1;

            char c = (char)0;

            for (int i = startIndex; i < value.Length; i++)
            {
                if (value[i] == characterToFind)
                {
                    if (value[i] != c)
                        c = value[i];
                    else
                    {
                        //at least one repeating character
                        return i - 1;
                    }
                }
                else
                    c = (char)0;
            }

            return -1;
        }

        /// <summary>
        /// Searches a string for a repeated instance of the specified <paramref name="characterToFind"/>.
        /// </summary>
        /// <param name="value">The string to process.</param>
        /// <param name="characterToFind">The character of interest.</param>
        /// <returns>The index of the first instance of the character that is repeated or (-1) if no repeated chars found.</returns>
        public static int IndexOfRepeatedChar(this string value, char characterToFind)
        {
            return IndexOfRepeatedChar(value, characterToFind, 0);
        }

        /// <summary>
        /// Searches a string for an instance of a repeated character.
        /// </summary>
        /// <param name="value">The string to process.</param>
        /// <returns>The index of the first instance of any character that is repeated or (-1) if no repeated chars found.</returns>
        public static int IndexOfRepeatedChar(this string value)
        {
            return IndexOfRepeatedChar(value, 0);
        }

        /// <summary>
        /// Searches a string for an instance of a repeated character from specified <paramref name="startIndex"/>.
        /// </summary>
        /// <param name="value">The string to process.</param>
        /// <param name="startIndex">The index from which to begin the search.</param>
        /// <returns>The index of the first instance of any character that is repeated or (-1) if no repeated chars found.</returns>
        public static int IndexOfRepeatedChar(this string value, int startIndex)
        {
            if (string.IsNullOrEmpty(value))
                return -1;

            if (startIndex < 0)
                return -1;

            char c = (char)0;

            for (int i = startIndex; i < value.Length; i++)
            {
                if (value[i] != c)
                    c = value[i];
                else
                {
                    //at least one repeating character
                    return i - 1;
                }
            }
            return -1;
        }

        /// <summary>
        /// Returns the index of the last repeated index of the first group of repeated characters that begin with the <paramref name="characterToFind"/>.
        /// </summary>
        /// <param name="value">String to process.</param>
        /// <param name="characterToFind">The character of interest.</param>
        /// <param name="startIndex">The index from which to begin the search.</param>
        /// <returns>The index of the last instance of the character that is repeated or (-1) if no repeated chars found.</returns>
        private static int LastIndexOfRepeatedChar(string value, char characterToFind, int startIndex)
        {
            if (startIndex > value.Length - 1)
                return -1;

            int i = value.IndexOf(characterToFind, startIndex);

            if (i == -1)
                return -1;

            for (int j = i + 1; j < value.Length; j++)
            {
                if (value[j] != characterToFind)
                    return j - 1;
            }

            return value.Length - 1;
        }

        /// <summary>
        /// Places an ellipsis in the middle of a string as it is trimmed to length specified.
        /// </summary>
        /// <param name="value">The string to process.</param>
        /// <param name="length">The maximum returned string length; mimimum value is 5.</param>
        /// <returns>
        /// A trimmed string of the specified <paramref name="length"/> or empty string if <paramref name="value"/> is null or empty.
        /// </returns>
        /// <remarks>
        /// Returned string is not padded to fill field length if <paramref name="value"/> is shorter than length.
        /// </remarks>
        public static string TrimWithEllipsisMiddle(this string value, int length)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            if (length < 5)
                length = 5;

            value = value.Trim();

            if (value.Length <= length)
                return value;

            int s1_Len = (int)(length / 2) - 1;

            return string.Concat(value.Substring(0, s1_Len), "...", value.Substring(value.Length - s1_Len + 1 - length % 2));
        }

        /// <summary>
        /// Places an ellipsis at the end of a string as it is trimmed to length specified.
        /// </summary>
        /// <param name="value">The string to process.</param>
        /// <param name="length">The maximum returned string length; mimimum value is 5.</param>
        /// <returns>
        /// A trimmed string of the specified <paramref name="length"/> or empty string if <paramref name="value"/> is null or empty.
        /// </returns>
        /// <remarks>
        /// Returned string is not padded to fill field length if <paramref name="value"/> is shorter than length.
        /// </remarks>
        public static string TrimWithEllipsisEnd(this string value, int length)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            if (length < 5)
                length = 5;

            value = value.Trim();

            if (value.Length <= length)
                return value;

            return string.Concat(value.Substring(0, length - 3), "...");
        }
    }
}
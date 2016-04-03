#if DEBUG
#define ENABLE_DEBUG_STRUCTURES
#endif

using System.Collections.Generic;

namespace AdvanceDataStructures
{
    public class Trie
    {
        #region Constants
        const int AlphabetSize = 26;
        #endregion

        #region Internal DataStructures
        private class TrieNode
        {
#if ENABLE_DEBUG_STRUCTURES
            internal char cData;
            internal int iData;
            internal string sWordSoFar;
#endif
            internal TrieNode()
            {
                IsWordEnd = false;
                Children = new TrieNode[AlphabetSize];
            }

            internal bool IsWordEnd
            {
                get;
                set;
            }

            internal TrieNode[] Children
            {
                get;
                set;
            }
        }
        #endregion

        #region Private Members
        int m_iWordCount;
        TrieNode m_tnRoot;
#if ENABLE_DEBUG_STRUCTURES
        List<string> m_lsDebugListOfWords;
#endif
        #endregion

        #region Constructor(s)
        public Trie()
        {
#if ENABLE_DEBUG_STRUCTURES
            m_lsDebugListOfWords = new List<string>();
#endif
            m_tnRoot = new TrieNode();
        }
        #endregion

        #region Public Properties
        public int WordCount
        {
            get
            {
                return m_iWordCount;
            }
        }
#if ENABLE_DEBUG_STRUCTURES
        public bool IsTrieIntact
        {
            get
            {
                return (m_iWordCount == m_lsDebugListOfWords.Count);
            }
        }
#endif
        #endregion

        #region Public Methods
        /// <summary>
        /// Add a specified word to the Trie
        /// </summary>
        /// <param name="sWordToAdd">Word to be added</param>
        /// <returns>True if addition succeeds and False otherwise.</returns>
        public bool AddWord(string sWordToAdd)
        {
            if (string.IsNullOrEmpty(sWordToAdd))
            {
                return false;
            }
#if ENABLE_DEBUG_STRUCTURES
            m_lsDebugListOfWords.Add(sWordToAdd);
            System.Text.StringBuilder sb = new System.Text.StringBuilder(sWordToAdd.Length);
#endif
            TrieNode tnTemp = m_tnRoot, t;
            int i = 0;
            for (; i < sWordToAdd.Length; i++)
            {
                t = tnTemp.Children[(sWordToAdd[i] - 'a')];
                if (null == t)
                {
                    // We've reached the point where pre-existing nodes are all traversed;
                    // We'll have to start creating new nodes for the remaining chars in the string.
                    break;
                }
                else
                {
                    // Continue traversing the Trie until we hit an empty path.
#if ENABLE_DEBUG_STRUCTURES
                    sb.Append(sWordToAdd[i]);
#endif
                    tnTemp = t;
                }
            }
            // Creation of new path.
            for (; i < sWordToAdd.Length; i++)
            {
                tnTemp = (tnTemp.Children[(sWordToAdd[i] - 'a')] = new TrieNode());
#if ENABLE_DEBUG_STRUCTURES
                tnTemp.cData = sWordToAdd[i];
                tnTemp.iData = sWordToAdd[i] - 'a';
                sb.Append(sWordToAdd[i]);
                tnTemp.sWordSoFar = sb.ToString();
#endif
            }
            tnTemp.IsWordEnd = true;
#if ENABLE_DEBUG_STRUCTURES
            if (sWordToAdd.Equals(sb.ToString()))
            {
#endif
                m_iWordCount++;
#if ENABLE_DEBUG_STRUCTURES
            }
#endif
            return true;
        }
        #endregion
    }
}

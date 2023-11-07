using AlgorithmsDataStructures2;

namespace School.ADS2
{
    public static class SimpleTreeExtensions
    {
        public static void SetNodesLevel(this SimpleTree<int> tree)
        {
            SetNodeValueToLevel(tree.Root, 0);
        }

        private static void SetNodeValueToLevel(SimpleTreeNode<int> node, int level)
        {
            if (node == null)
            {
                return;
            }

            node.NodeValue = level;
            if (node.Children != null)
            {
                foreach (var child in node.Children)
                {
                    SetNodeValueToLevel(child, level + 1);
                }
            }
        }

        public static int GetNodeLevel<T>(this SimpleTree<int> tree, SimpleTreeNode<T> node)
        {
            return GetNodeLevel(node, 0);
        }

        private static int GetNodeLevel<T>(SimpleTreeNode<T> currentNode, int currentLevel)
        {
            if (currentNode.Parent == null)
            {
                return currentLevel;
            }

            return GetNodeLevel(currentNode.Parent, currentLevel + 1);
        }
    }
}

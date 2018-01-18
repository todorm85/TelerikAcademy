namespace Tree
{
    using System.Collections.Generic;

    public class TreeNode<T>
    {
        public TreeNode(T value)
        {
            this.Value = value;
            this.Children = new HashSet<TreeNode<T>>();
        }

        public T Value { get; set; }

        public TreeNode<T> Parent { get; set; }

        public ICollection<TreeNode<T>> Children { get; set; }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}
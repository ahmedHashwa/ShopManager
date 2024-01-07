#region using directives

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Windows.Forms;

#endregion

namespace ShopManager.Controls.Basic
{
    internal class MyCollectionEditor : CollectionEditor
    {
        private static int _i;

        public MyCollectionEditor(Type type)
            : base(type)
        {
        }

        protected override Type CreateCollectionItemType()
        {
            return typeof (DataGridViewColumn);
        }

        protected override Type[] CreateNewItemTypes()
        {
            var types = new[]
                            {
                                typeof (DataGridViewTextBoxColumn),
                                typeof (DataGridViewComboBoxColumn),
                                typeof (DataGridViewCheckBoxColumn),
                                typeof (DataGridViewButtonColumn),
                                typeof (DataGridViewImageColumn),
                                typeof (DataGridViewLinkColumn)
                            };
            return types;
        }

        protected override object CreateInstance(Type itemType)
        {
            var column = itemType.GetConstructor(Type.EmptyTypes).Invoke(null) as DataGridViewColumn;
            if (column != null)
            {
                column.Name = itemType.Name + (++_i);

                return column;
            }
            return null;
        }
    }

    public class MyCodeDomSerializer : CodeDomSerializer
    {
        public override object Deserialize(IDesignerSerializationManager manager, object codeObject)
        {
            var baseClassSerializer =
                (CodeDomSerializer) manager.GetSerializer(typeof (ParentControl).BaseType, typeof (CodeDomSerializer));


            return baseClassSerializer.Deserialize(manager, codeObject);
        }

        public override object Serialize(IDesignerSerializationManager manager, object value)
        {
            //System.Diagnostics.Debugger.Break();
            var baseClassSerializer =
                (CodeDomSerializer) manager.GetSerializer(typeof (ParentControl).BaseType, typeof (CodeDomSerializer));
            // serialize the UserControl
            object codeObject = baseClassSerializer.Serialize(manager, value);

            if (codeObject is CodeStatementCollection)
            {
                var statements = (CodeStatementCollection) codeObject;

                //// The code statement collection is valid, so add a comment.
                //string commentText = "";
                //CodeCommentStatement comment = new CodeCommentStatement(commentText);

                //statements.Insert(0, comment);
                //// serialize the inner DataGridView's columns

                if (value is ParentControl)
                {
                    DataGridViewColumnCollection innercolumns = (value as ParentControl).Columns;
                    // declare the variable collection of columns in the inner DataGridView
                    var parameterList = new List<CodeVariableReferenceExpression>();


                    CodeStatementCollection colStatements;
                    foreach (DataGridViewColumn col in innercolumns)
                    {
                        // serialize each column
                        colStatements = new CodeStatementCollection();

                        var colObjectCreate = new CodeObjectCreateExpression(col.GetType());

                        var colVariableDeclaration = new CodeVariableDeclarationStatement(col.GetType(), col.Name);

                        var colAssignCreate = new CodeAssignStatement(new CodeVariableReferenceExpression(col.Name),
                                                                      colObjectCreate);
                        // serialize the Width property of the column
                        var colAssignWidth =
                            new CodeAssignStatement(new CodeVariableReferenceExpression(col.Name + ".Width"),
                                                    new CodePrimitiveExpression(col.Width)); //col.Width
                        var colFieldReference =
                            SerializeToExpression(manager, col) as CodeFieldReferenceExpression;
                        if (colFieldReference == null)
                        {
                            colStatements.Add(colVariableDeclaration);
                            colStatements.Add(colAssignCreate);
                            colStatements.Add(colAssignWidth);
                            parameterList.Add(new CodeVariableReferenceExpression(col.Name));
                        }
                        statements.AddRange(colStatements);
                    }

                    var target = SerializeToExpression(manager, value) as CodeFieldReferenceExpression;
                    // if the designer hasn't all the columns to the inner DataGridView's column collection, add them by ourselves.
                    if (target != null && parameterList.Count > 0)
                    {
                        var createArray = new CodeArrayCreateExpression(typeof (DataGridViewColumn),
                                                                        parameterList.ToArray());
                        var methodcall = new CodeMethodInvokeExpression(
                            new CodeVariableReferenceExpression(target.FieldName + ".Columns"), "AddRange",
                            createArray);
                        statements.Add(methodcall);
                    }
                }
            }
            return codeObject;
        }
    }
}
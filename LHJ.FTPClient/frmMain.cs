using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LHJ.FTPClient
{
    public partial class frmMain : Form
    {
        #region 1.Variable
        private System.Windows.Forms.ContextMenu contextMenu1 = new System.Windows.Forms.ContextMenu();
        private System.Windows.Forms.TextBox textSrc = new TextBox();
        private string savefullpath;//트리뷰에서 노드를 선택했을 때 저장되는 경로, 리스트뷰에서 이를 사용한다.
        private int imgcount = 0;
        private int imgcount2 = 0;
        private int foldericoncount = 0;
        private ImageList myImageList = null;
        private ImageList myImageList2 = null;
        private Queue treeque = new Queue();
        private ListViewItem Rlistviewitem = null;
        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public frmMain()
        {
            InitializeComponent();

            this.SetInitialize();
        }
        #endregion 3.Constructor


        #region 4.Override Method

        #endregion 4.Override Method


        #region 5.Set Initialize
        /// <summary>
        /// Set Initialize
        /// </summary>
        public void SetInitialize()
        {
            this.SetLastBuildDate();
            this.Icon = Properties.Resources._1496929034_Location_FTP;

            treelistviewIcon();
            localDriveTree();
            initListview();
        }
        #endregion 5.Set Initialize


        #region 6.Method
        private void SetLastBuildDate()
        {
            System.Version assemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            DateTime buildDate = new DateTime(2000, 1, 1).AddDays(assemblyVersion.Build).AddSeconds(assemblyVersion.Revision * 2);

            this.tsslLastBulidDate.Text = " [Last Build : " + buildDate.ToString("yyyy-MM-dd") + "]";
        }

        /// <summary>
        /// treeView와 listview에 들어갈 이미지 설정과 이미지 삽입
        /// </summary>
        private void treelistviewIcon()
        {
            myImageList2 = new ImageList();
            myImageList = new ImageList();
            treeView1.ImageList = myImageList2;
            listView1.SmallImageList = myImageList;
        }

        /// <summary>
        /// 현재 로컬 드라이브를 불러오는 함수
        /// </summary>
        private void localDriveTree()
        {
            //treeView1.BeginUpdate(); //성능향상을 위해 트리뷰를 한번만 그려주기 처리
            treeView1.MouseDown += new MouseEventHandler(treeView1_MouseDown); //트리뷰에서 마우스를 눌렀을 때 핸들러
                                                                               //현재 로컬의 논리 드라이브를 얻어와서 트리뷰에 출력한다.
            string[] drives = Directory.GetLogicalDrives();

            foreach (string str in drives)
            {
                //시스템아이콘 추가
                myImageList2.Images.Add(SystemIcon.GetIcon(str, true));
                //treeview에 불러온 논리드라이브를 붙인다.
                TreeNode rootnode = treeView1.Nodes.Add(str);
                treeque.Enqueue(rootnode);
                //드라이브 이미지 설정
                rootnode.ImageIndex = imgcount2;
                rootnode.SelectedImageIndex = imgcount2;
                imgcount2++;
            }

            while (treeque.Count > 0)
            {
                //각각 불러온 논리 드라이브 하위 폴더와 파일을 찾기 위해 nextnodeShow() 함수를 호출한다.
                nextnodeShow((TreeNode)treeque.Dequeue(), true);
            }
        }

        /// <summary>
        /// treeview에서클릭한 노드 알아내기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button.Equals(MouseButtons.Left))//마우스 왼쪽 버튼에만 반응하게끔
                {
                    //클릭한 좌표를 이용하여 GetNodeAt()메소드를 통해 클릭한 노드를 알아낸다.
                    TreeNode selectednode = treeView1.GetNodeAt(e.X, e.Y);
                    //클릭한 노드가 treeView1에서 선택되게 만든다.
                    treeView1.SelectedNode = selectednode;
                    //선택된 노드의 전체 경로를 얻어온다.
                    string selectednode_fullpath = selectednode.FullPath;
                    savefullpath = selectednode_fullpath; // listView1_MouseUp()함수에서 사용한다.
                    textSrc.Text = savefullpath.ToString();// 전체경로 출력
                    getFolderAndFile(selectednode_fullpath);
                }

            }
            catch (System.Exception)
            {
            }
        }

        /// <summary>
        /// listview 초기화
        /// </summary>
        private void initListview()
        {
            listView1.Clear();
            listView1.View = View.Details; //자세히 보기 설정
            listView1.LabelEdit = true;//라벨변경모드
            listView1.Columns.Add("파일명", 170, HorizontalAlignment.Left);
            listView1.Columns.Add("파일크기", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("수정한날짜", 150, HorizontalAlignment.Left);
            listView1.MouseUp += new MouseEventHandler(listView1_MouseUp);
            listView1.MouseDown += new MouseEventHandler(listView1_MouseDown);
            contextMenu1.Popup += new EventHandler(contextMenu1_Popup);
        }

        /// <summary>
        /// listview에서 더블클릭한 subItem 알아내서 하위 디렉토리 알아내기.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if ((e.Clicks == 2) && (e.Button.Equals(MouseButtons.Left))) //두번(더블) 클릭하고 왼쪽버튼을 클릭했을 때
                {
                    ListViewItem listviewitem = listView1.GetItemAt(e.X, e.Y);//좌표에 해당하는 아이템을 얻어옴
                    if (listviewitem.Index == 0)//첫번째 아이템일때
                    {
                        string temp_savefullpath = savefullpath.Remove(savefullpath.LastIndexOf("\\"), savefullpath.Length - savefullpath.LastIndexOf("\\"));
                        if (temp_savefullpath.IndexOf("\\") > 0) //c:\나 d:\ 와 같은 루트를 넘어가지 않게하는 처리
                        {
                            getFolderAndFile(temp_savefullpath);
                            textSrc.Text = temp_savefullpath.ToString();// 전체경로 출력
                        }
                    }
                    else//첫번째 아이템이 아닐때
                    {
                        getFolderAndFile(String.Concat(savefullpath, "\\", listviewitem.Text));
                        textSrc.Text = savefullpath.ToString();// 전체경로 출력
                    }
                }
            }
            catch (System.Exception)
            {
            }
        }


        /// <summary>
        /// listview에서 마우스 오른쪽 클릭시 단축메뉴보이기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                ListViewItem listviewitem = listView1.GetItemAt(e.X, e.Y); //클릭된 마우스의 좌표로 부터 선택된 아이템을 찾아낸다.
                Rlistviewitem = listviewitem; // 클릭된 아이템을 임시로 저장해 놓는다.

                if (e.Button.Equals(MouseButtons.Right)) // 리스트 뷰에서 마우스 오른쪽을 클릭했을 때 해당 리스트에 단축메뉴가 나타나게 하는 처리
                {
                    if (listviewitem.Index != 0)
                    {
                        //if(listView1.SelectedItems.Count==1 || listView1.SelectedItems.Count==0)
                        //{
                        listviewitem.Selected = true;
                        //}
                        contextMenu1.Popup += new EventHandler(contextMenu1_Popup); //contextMenu 이벤트 처리
                        contextMenu1.Show(listView1, new Point(e.X, e.Y)); //contxtMenu 실질적으로 보여주기
                    }
                }
            }
            catch (System.Exception)
            {
            }
        }

        /// <summary>
        /// ContextMenu 설정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenu1_Popup(object sender, EventArgs e) //단축 메뉴 팝업 이벤트가 발생했을시 단축메뉴 생성하기.
        {
            //MessageBox.Show(e.X+","+e.Y+"오른쪽 클릭");
            MenuItem menuitem1 = new MenuItem("열기");
            MenuItem menuitem2 = new MenuItem("잘라내기");
            MenuItem menuitem3 = new MenuItem("복사");
            MenuItem menuitem4 = new MenuItem("삭제");
            MenuItem menuitem5 = new MenuItem("이름바꾸기");
            MenuItem menuitem6 = new MenuItem("등록정보");

            if (contextMenu1.SourceControl == listView1)//ListView에 해당되는 contextMenu 설정
            {
                contextMenu1.MenuItems.Clear();
                contextMenu1.MenuItems.Add(menuitem1);
                contextMenu1.MenuItems.Add(menuitem2);
                contextMenu1.MenuItems.Add(menuitem3);
                contextMenu1.MenuItems.Add(menuitem4);
                contextMenu1.MenuItems.Add(menuitem5);
                contextMenu1.MenuItems.Add(menuitem6);
            }
            if (listView1.SelectedItems.Count >= 2)
            {
                menuitem1.Enabled = false;
                menuitem2.Enabled = true;
                menuitem3.Enabled = true;
                menuitem4.Enabled = true;
                menuitem5.Enabled = false;
                menuitem6.Enabled = false;
            }
            else
            {
                menuitem1.Enabled = true;
                menuitem2.Enabled = true;
                menuitem3.Enabled = true;
                menuitem4.Enabled = true;
                menuitem5.Enabled = true;
                menuitem6.Enabled = true;
            }

            menuitem1.Click += new EventHandler(menuitem1_Click);
            menuitem5.Click += new EventHandler(menuitem5_Click);
        }

        /// <summary>
        /// contextmenue의 열기 클릭시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuitem1_Click(object sender, EventArgs e)
        {
            getFolderAndFile(String.Concat(savefullpath, "\\", Rlistviewitem.Text));
            textSrc.Text = savefullpath.ToString();// 전체경로 출력
        }

        /// <summary>
        /// contextmenu의 이름바꾸기 클릭시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuitem5_Click(object sender, EventArgs e)
        {
            Rlistviewitem.BeginEdit();
        }

        /// <summary>
        /// 폴더와 파일 검색 후 ListView에 추가 시켜주는 함수
        /// </summary>
        /// <param name="str"></param>
        private void getFolderAndFile(string str)
        {
            DirectoryInfo dinfo = new DirectoryInfo(@str);
            savefullpath = str;// 경로 설정
                               //MessageBox.Show(str);
            if (dinfo.Exists) //폴더일 경우
            {
                //listview 항목들 초기화
                setListview();

                //이전경로 표시
                ListViewItem item0 = new ListViewItem("..", foldericoncount);
                item0.SubItems.Add("");
                item0.SubItems.Add("");
                listView1.Items.Add(item0);

                //인자로 넘어온 경로에서 하위 경로에 해당하는 디렉토리 검색
                DirectoryInfo[] directories = dinfo.GetDirectories();
                //리스트뷰에 검색된 디렉토리를 추가
                foreach (DirectoryInfo directory in directories)
                {
                    myImageList.Images.Add(SystemIcon.GetIcon(directory.FullName, true));//시스템아이콘 추가
                    ListViewItem item1 = new ListViewItem(directory.Name.ToString(), imgcount);

                    imgcount++;
                    item1.SubItems.Add("");
                    item1.SubItems.Add(directory.CreationTime.ToShortDateString());
                    listView1.Items.Add(item1);
                }


                //인자로 넘어온 경로에서 하위 경로에 해당하는 파일 검색
                FileInfo[] files = dinfo.GetFiles();
                //리스트뷰에 검색된 파일을 추가
                foreach (FileInfo fil in files)
                {
                    myImageList.Images.Add(SystemIcon.GetIcon(fil.FullName, true));
                    ListViewItem item2 = new ListViewItem(fil.Name.ToString(), imgcount);
                    imgcount++;
                    long fil_len = fil.Length / 1024;
                    item2.SubItems.Add(fil_len.ToString() + "KB");
                    item2.SubItems.Add(fil.CreationTime.ToShortDateString());
                    listView1.Items.Add(item2);
                }
            }
            else//파일일 경우
            {
                //파일실행
                file_execute(savefullpath);
                //경로는 이전의 폴더 경로로 다시 설정
                int lastposition = savefullpath.ToString().LastIndexOf("\\");
                savefullpath = savefullpath.Substring(0, lastposition);
            }
            //listView1.Focus();

        }

        /// <summary>
        /// 폴더와 파일을 검색하여 treeview에 삽입시켜 주는 함수.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="speedup"></param>
        private void nextnodeShow(TreeNode node, bool speedup)
        {
            try
            {
                string fullname = node.FullPath;
                DirectoryInfo dinfo = new DirectoryInfo(@fullname);
                if (dinfo.Exists)//폴더가 존재할 때까지
                {
                    //인자로 넘어온 경로에서 하위 경로에 해당하는 디렉토리 검색
                    DirectoryInfo[] directories = dinfo.GetDirectories();

                    int speedupflag = 0;
                    foreach (DirectoryInfo directory in directories)
                    {
                        TreeNode node1 = node.Nodes.Add(directory.ToString());
                        //MessageBox.Show(node1.FullPath);
                        myImageList2.Images.Add(SystemIcon.GetIcon(directory.FullName.ToString(), true));
                        node1.ImageIndex = imgcount2;
                        node1.SelectedImageIndex = imgcount2;
                        imgcount2++;
                        speedupflag++;
                        if (speedup)
                        {
                            if (speedupflag > 0)
                            {
                                break;
                            }
                        }
                        nextnodeShow(node1, true);
                    }

                    //인자로 넘어온 경로에서 하위 경로에 해당하는 파일검색
                    /*
					FileInfo [] files = dinfo.GetFiles() ;
					foreach(FileInfo fil in files)
					{
						myImageList2.Images.Add(SystemIcon.GetIcon(fil.FullName.ToString(),true));
						node.Nodes.Add(fil.ToString());
						node.ImageIndex=imgcount2;
						node.SelectedImageIndex=imgcount2;
						imgcount2++;
					}
					*/

                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 파일을 실행 시킨다.
        /// </summary>
        /// <param name="str">실행할 파일경로</param>
        private void file_execute(string str)
        {
            System.Diagnostics.Process.Start(str);
        }

        /// <summary>
        /// 리스트뷰가 다시 그려질때 Columns에 해당하는 내용이 지워지기 때문에 다시 columns를 설정해 줘야한다.
        /// </summary>
        private void setListview()
        {
            listView1.Clear();
            listView1.View = View.Details; //자세히 보기 설정
                                           //listView1.LabelEdit=false;
            listView1.Columns.Add("파일명", 170, HorizontalAlignment.Left);
            listView1.Columns.Add("파일크기", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("수정한날짜", 150, HorizontalAlignment.Left);
        }
        #endregion 6.Method

        #region 7.Event

        #endregion 7.Event

        private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.Nodes.Clear();
            e.Node.Nodes.Insert(0, new TreeNode("blanknode"));
        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            nextnodeShow(e.Node, false);
            e.Node.FirstNode.Remove();
        }

        private void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            try
            {
                string prevfullpath = String.Concat(savefullpath, "\\", Rlistviewitem.Text);
                string nextfullpath = String.Concat(savefullpath, "\\", e.Label);
                Directory.Move(prevfullpath, nextfullpath);
                //getFolderAndFile(nextfullpath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

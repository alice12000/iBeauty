   M S B A M L   `   `   `  ����   IBeauty'    !IBeauty.Telas.CadastroFuncionario   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  Tela Inicial��$	��450��$	��800��
������� � 	Resources    CustomRadioButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Orientation �� CornerRadius A�Name	 �� Triggers
 P� Property P� Value �� 
TargetName��%�  &	        �� " 	�.���  � �� �� " 	�.R��� $ 
Horizontal=�.+�� .+��� $��20��$��20�����#B6667C$��2q�$ 10��
������ $��0 0 2 0q�A� $ CheckedCircle�����#B6667C$y�	Collapsed=�$��10��$��10��$��Center=�$��Center=��� $��Center=�	 P� 
 �@d�	IsChecked$
 TrueY�. ��� $ CheckedCircle�� � y�$ Visible=�P� 
 �@d�	IsChecked$ FalseY�. ��� $ CheckedCircle�� � y�$ 	Collapsed=�.���  � RowDefinitions �� $��30 ��� $��* �.+�� $��0�����	#FFB6667C.+��� $��Poppins)�$��12(�
�������$��50,0,0,0q�$��Center=�$
��Left=�$	��100���� $��20(�	iBeauty�� -   $��CloseButton��$��Right=�$��Center=�
������ $��0q�.���� $��\Imagens\cancelar.png��$��20��$��20��$��5q��� -   $��BtnToggleMenu�����	#FFB6667C$��0q�$
��Left=�$��Center=�$��0,0,0,0q�$��50��$��30��.���� $��\Imagens\menu.png��$��Uniform=�$��5q�� $��1�� � ColumnDefinitions �� $
��Auto ��� $��* �.+�� -    �Name$ 	MenuPanel�����	#FF222222$	��250��$
��Left=�$��Stretch=�$y�	Collapsed=�.+��� $ Vertical=�$��	10,0,10,0q�.+��� $ 
Horizontal=�$��Right=�.+��� 
������ $��0q�$��50��
�������$��Right=�$��15,0,0,0q�$��JosefinSans)�$��14(�.���� $ 
Horizontal=�$��Center=�.+��� $��/Imagens/casa.png��$��20��$��20��$��0 0 10 0q��� $
��Menu��$��Center=��� $ 
Horizontal=�$��Right=�.+��� 
������ $��0q�$��50��
�������$��Right=�$��15,0,0,0q�$��JosefinSans)�$��14(�.���� $ 
Horizontal=�$��Center=�.+��� $$��\Imagens\adicionar-usuario.png��$��20��$��20��$��0 0 10 0q��� $��	Cadastrar��$��Center=��� $ 
Horizontal=�$��Right=�.+��� 
������ $��0q�$��50��
�������$
��Left=�$��15,0,0,0q�$��JosefinSans)�$��14(�.���� $ 
Horizontal=�$��Center=�.+��� $��\Imagens\usuario.png��$��20��$��20��$��0 0 10 0q��� $��Login��$��Center=�� $��1��
������� �� �� $	��39* �.+��� $��Cadastro Funcionario��$��Poppins)�$��24(����	#FFB6667C$��0,30,0,0q�$��Center=�$��1���� ���	#FFB6667C$��2q�$ 10��$��70,150,70,150q� �� Padding$ 20q�$��2��._�� $��1�� �� $
��1.3* ��� $��* �.+�� .+��� .+��� $��1��$ 
Horizontal=�$��0,0,0,0q�.+��� $��Nome completo:��$��14(�$��0,0,0,5q�$��Poppins)��� $��	Telefone:��$��14(�$��	295,0,0,5q�$��Poppins)��� $ 
Horizontal=�$��0,0,0,10q�.+��� $��40��$	��440��$��10q�$��JosefinSans)�$��14(�$��1q����	#FFB6667C$��0,0,0,10q�.�� ��%:   '��       �� " ��.���  �@��CornerRadius$ 10��.���� $��40��$	��300��$��10q�$��JosefinSans)�$��14(�$��1q����	#FFB6667C$��	10,0,0,10q�.�� ��%:   '��       �� " ��.���  �@��CornerRadius$ 10��.���� $ 
Horizontal=�$��0,0,0,0q�.+��� $��Gênero:��$��14(�$��0,0,0,5q�$��Poppins)��� $��Endereço de e-mail:��$��14(�$��	260,0,0,5q�$��Poppins)��� $ 
Horizontal=�$��0,0,0,10q�.+��� $��40��$	��300��$��10q�$��JosefinSans)�$��14(�$��1q����	#FFB6667C$��0,0,0,0q�.@��� $��	Masculino���� $��Feminino���� $��Outro���� $��40��$	��450��$��10q�$��JosefinSans)�$��14(�$��1q����	#FFB6667C$��10,0,0,0q�.�� ��%:   '��       �� " ��.���  �@��CornerRadius$ 10��.���� $ 
Horizontal=�.+��� $��Observação:��$��14(�$��0,0,0,5q�$��Poppins)��� $��Data nascimento:��$��14(�$��	320,0,0,5q�$��Poppins)��� $ 
Horizontal=�.+��� $	��150��$	��400��$��JosefinSans)�$��14(�$��1q����	#FFB6667C$��0,0,0,0q�.�� ��%:   '��       �� " ��.���  �@��CornerRadius$ 10��.���� $��40��$	��350��$��JosefinSans)�$��14(�$��1q����	#FFB6667C$��10,0,0,0q�$	��Top=�.�� ��%:   '��       �� " ��.���  �@��CornerRadius$ 10��.��� $��2��.+��� .+��� .+��� $��Expediente:��$��14(�$��Poppins)��� $ 
Horizontal=�.+��� $��40��$	��300��$��JosefinSans)�$��14(�$��1q����	#FFB6667C.@��� $��Horário geral���� $��Novo expediente +��$��10, 0, 0, 0q�$��Poppins)�$��16(����	#FFB6667C
�������$
��10,5q�$��Center=��� .+��� $��
Categoria:��$��14(�$��Poppins)��� $ 
Horizontal=�.+�	� $��Cabelo��$��
0, 0, 5, 0q� 	� 	GroupName$ Servicos��#��[  	� $
��Unha��$��
0, 0, 5, 0q�$ Servicos��#��[  	� $��Rosto��$��
0, 0, 5, 0q�$ Servicos��#��[  	� $��Corpo��$��
0, 0, 5, 0q�$ Servicos��#��[  �� $ 
Horizontal=�$��0, 20, 0, 0q�.+��� $��Poppins)�$��16(����#DFAEBB$
��10,5q�$��Center=����	#FFB6667C���	#FFB6667C ��%:   '��       �� " ��.���  �@��CornerRadius$ 10��.���� $ 
Horizontal=�$��Center=�.+��� $��/imagens/acesso.png��$��20��$��20��$��0 0 10 0q��� $��Perfil de acesso��$��Center=��� $ Vertical=�.+��� $#��Defina o privilegio de acesso��$��10(�$��Poppins)��� $ ��acesso desse profissional.��$��10(�$��Poppins)��� $ 
Horizontal=�$��0, 20, 0, 0q�.+�	� $��Possui agenda��$��
0, 0, 5, 0q�$ Servicos��#��[  	� $��Ativo��$��
0, 0, 5, 0q�$ Servicos��#��[  �� $ 
Horizontal=�$��0, 30, 0, 0q�.+��� -   $��Salvar��$��Poppins)�$��16(����	#FFB6667C
�������$
��10,5q�$��Center=�$��0q�$��0,0,0,0q� ��%:   '��       �� " ��.���  �@��CornerRadius$ 10���� -   $��Cancelar��$��Poppins)�$��16(����	#FFB6667C
�������$
��10,5q�$
��Left=�$��0q�$��10,0,0,0q� ��%:   '��       �� " ��.���  �@��CornerRadius$ 10��
using AudioLibrary.Repositories;
using AudioLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AudioLibrary.Pages;

/// <summary>
/// Interaction logic for SongsPage.xaml
/// </summary>
public partial class SongsPage : Page
{
    private SongsViewModel _viewModel;
    public SongsPage(Frame mainFrame)
    {
        InitializeComponent();

        var authorRepository = new AuthorRepository();
        var jenreRepository = new JenreRepository();

        var authors = authorRepository.GetAll();
        var jenres = jenreRepository.GetAll();
        var songRepository = new SongRepository(authors, jenres);
        _viewModel = new SongsViewModel(mainFrame, songRepository, authors, jenres);
        DataContext = _viewModel;
    }
}

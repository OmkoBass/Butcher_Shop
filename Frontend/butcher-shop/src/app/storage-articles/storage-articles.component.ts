import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Location } from "@angular/common";
import { StorageService } from '../services/storageService/storage.service';
import { MatDialog } from '@angular/material/dialog';
import { EditArticleDialogComponent } from '../edit-article-dialog/edit-article-dialog.component';
import { ArticleService } from '../services/articleService/article.service';
import { EditCustomerDialogComponent } from '../edit-customer-dialog/edit-customer-dialog.component';

@Component({
  selector: 'app-storage-articles',
  templateUrl: './storage-articles.component.html',
  styleUrls: ['./storage-articles.component.css']
})
export class StorageArticlesComponent implements OnInit {
  loading = true;
  storage = null;
  searchStorageValue = null;
  submitting = false;

  constructor(
    private router: Router,
    private location: Location,
    private storageService: StorageService,
    private snackBar: MatSnackBar,
    private dialog: MatDialog,
    private articleService: ArticleService
  ) { }

  ngOnInit(): void {
      const urlParam = this.router.url.split("/")[2];

      this.storageService.GetStorageById(urlParam)
      .subscribe(res => {
        this.storage = res;
        this.loading = false;
      }, () => {
        this.snackBar.open('Something went wrong!', 'Okay!')
        this.loading = false;
      });
  }

  handleOpenEditDialog(article) {
    this.dialog.open(EditArticleDialogComponent, {
      data: {
        id: article.id,
        name: article.name,
        price: article.price,
        storageId: this.storage.id
      },
      width: '60%',
      minWidth: '320px'
    })
    .afterClosed()
    .subscribe(res => {
      if(res) {
        this.storage.articles = this.storage.articles.map(article => {
          if(article.id === res.data.id) {
            return res.data;
          }
  
          return article;
        });
      }
    });
  }

  handleShowAddEmployeeDialog() {
    this.dialog.open(EditArticleDialogComponent, {
      data: {
        new: true,
        storageId: this.storage.id
      },
      width: '60%',
      minWidth: '320px'
    })
    .afterClosed()
    .subscribe(res => {
      if(res) {
        this.storage.articles = [...this.storage.articles, res.data];
      }
    });
  }

  handleDeleteArticle(id) {
    this.submitting = true;
    this.articleService.DeleteArticle(id)
    .subscribe(_ => {
      this.storage.articles = this.storage.articles.filter(article => article.id !== id);
      this.snackBar.open('Article deleted!', 'Okay!');
      this.submitting = false;
    }, () => {
      this.snackBar.open('Something went wrong!', 'Okay!');
      this.submitting = false;
    });
  }

  handleOpenAddCustomerDialog(articleId: string) {
    this.dialog.open(EditCustomerDialogComponent, {
      data: {
        new: true,
        butcherStoreId: this.storage.butcherStoreId,
        articleId: articleId
      },
      width: '60%',
      minWidth: '320px'
    })
    .afterClosed()
    .subscribe(res => {
      if(res) {
        this.storage.articles = this.storage.articles.filter(article => article.id !== res.data.id);
      }
    });
  }

  handleSearch(value) {
    this.searchStorageValue = value;
  }

  handleGoBack() {
    this.location.back();
  }
}

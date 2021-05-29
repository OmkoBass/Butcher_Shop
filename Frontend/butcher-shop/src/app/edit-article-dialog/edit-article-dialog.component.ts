import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ArticleService } from '../services/articleService/article.service';

@Component({
  selector: 'app-edit-article-dialog',
  templateUrl: './edit-article-dialog.component.html',
  styleUrls: ['./edit-article-dialog.component.css']
})
export class EditArticleDialogComponent implements OnInit {
  articleForm: FormGroup
  submitting = false;

  constructor(
    private formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public article,
    public dialogRef : MatDialogRef<EditArticleDialogComponent>,
    private articleService: ArticleService,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.articleForm = this.formBuilder.group({
      name: [
        this.article.name,
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(64),
        ]
      ],
      price: [
        this.article.price,
        [
          Validators.required,
          Validators.min(1)
        ]
      ]
    });
  }

  handleSubmit(form) {
    this.submitting = true;

    const article = { ...form.value, storageId: this.article.storageId }

    if(this.article.new) {
      this.articleService.CreateArticle(article)
      .subscribe(res => {
        this.dialogRef.close({ data: res });
        this.submitting = false;
        this.snackBar.open('Article Added!', 'Okay!');
      }, () => {
        this.submitting = false;
        this.snackBar.open('Something went wrong!', 'Okay!');
      });
    } else {
      this.articleService.UpdateAritcle(this.article.id, article)
      .subscribe(res => {
        this.dialogRef.close({ data: res });
        this.submitting = false;
        this.snackBar.open('Article Updated!', 'Okay!');
      }, () => {
        this.submitting = false;
        this.snackBar.open('Something went wrong!', 'Okay!');
      });
    }
  }

  closeDialog() {
    this.dialogRef.close();
  }

  get name() {
    return this.articleForm.get('name');
  }

  get price() {
    return this.articleForm.get('price');
  }
}

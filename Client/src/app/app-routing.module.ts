import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [{
  path: 'url',
  loadChildren: () =>
    import('./pages/url-table/url-table.module').then((u) => u.UrlTableModule)
},
  {
    path: '',
    redirectTo: 'url',
    pathMatch: 'full',
  },
  { path: '**', redirectTo: 'url' },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

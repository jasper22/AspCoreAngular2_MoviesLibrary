import { NgModule       }      from '@angular/core';
import { BrowserModule  }      from '@angular/platform-browser';
import { HttpModule     }      from "@angular/http";
import { FormsModule    }      from "@angular/forms";
import { RouterModule   }      from "@angular/router";
import "rxjs/Rx";

import { AboutComponent     }    from './About.component';
import { AppComponent       }    from './app.component';
import { HomeComponent      }    from './Home.component';
import { ItemService        }    from './Item.Service';
import { ItemListComponent  }    from './Items-list.component';
import { ItemDetailsComponent }  from './Item-details.component';
import { LoginComponent     }    from './Login.component';
import { PageNotFoundComponent}  from './Page-not-found.component';

import { AppRouting         }    from './app.routing';

@NgModule({
    // Specifies a list of directives/pipes that belong to this module.
    declarations: [
        AboutComponent,
        AppComponent,
        HomeComponent,
        ItemListComponent,
        ItemDetailsComponent,
        LoginComponent,
        PageNotFoundComponent
    ],

    // Specifies a list of modules whose exported directives/pipes should be available to templates in this module. This can also contain ModuleWithProviders.
    imports: [
        BrowserModule,
        HttpModule,
        FormsModule,
        RouterModule,
        AppRouting
    ],

    // Defines the set of injectable objects that are available in the injector of this module.
    providers: [
        ItemService
    ],

    // Specifies a list of directives/pipes/modules that can be used within the template of any component that is part of an Angular module that imports this Angular module.
    //exports: [],

    // Bootstrap
    bootstrap: [
        AppComponent
    ]
})


export class AppModule { }
# Hi everyone!

Recently, one of my clients said that the application needs a code update since he wanted to implement state management. 

This need appeared after a big expansion of the application. There was more functionality, new abstractions and new levels of components that needed to be managed. It became more and more difficult to use only the built-in Callback functions and this led to "chaos".

My task was to compare some libraries that allow me to implement the necessary functionality.

The first library was proposed by the Blazor-State client as it uses a fairly well-known approach using MediatR and is simple enough to solve our problem. As a second option I suggested Fluxor library because I knew the capabilities of this library and knew that it works with those libraries and with the functionality that already existed.


## Structure

I decided to run some tests and check which library is more resource-intensive. I tested it on a small project Blazor.Hybrid .NET 8. And also used diagnostic tools for analysis.

The structure of the application is shown below. It consists of four projects:

StateManagement.Performance.Fluxor - a project with test code for working with Fluxor.

StateManagement.Performance.State - a project with test code for working with Blazor-State.

StateManagement.Performance.Models - a shared project with a service and a model.

StateManagement.Performance.Shared - a shared project with .razor markup.



During the download of the application, I generate 10,000 objects and fill in the list with them. Later, after clicking the "Set table data" button, the state is called in the application and the data is transferred from the state to the UI to generate the table.




## Performance

I have divided all the data and tests into five points.

Immediately after downloading the application, but before calling the state.

Immediately after calling the state and displaying the table.

After calling the state again.

After changing the page.

After returning to the original page with the table.


We will be interested in fields such as StateMangement.Performance.Models.BodyModel is our list with objects and Microsoft.AspNetCore.Components.RenderTree.RenderTreeFrameArrayBuilder (in the future I will just call RenderTree) which will show us how much memory the table will take up.


## Blazor-State

In the picture below, you can see that the data has already been uploaded, but from the rather small size of the RenderTree, you can understand that nothing is displayed on the UI yet.



After updating the state, all 10,000 elements end up on the UI and therefore RenderTree takes up more memory.



After calling the state again, without changing the page, the page size has not changed. If there are small changes in the total volume, but we are not interested in this because the difference is very small.



The most interesting moment can be observed after changing the page. Since we are leaving the page where the table is displayed, there is no need to store all the information. As you can see in the picture, some of the necessary data gets into the pool, and our RenderTree becomes almost weightless. 

Therefore, if our project has a sufficiently large amount of data that is stored and used using State Mangement, it can lead to unnecessary calls to Garbage collector, since memory from such objects can easily run out, especially if we work with Android or iOS. 



The last step is to return to the original page. Here you can notice a discrepancy between what data is now and when we left the page. Everything else remains as it was with minor changes.



## Fluxor

Let's repeat the same steps with Fluxor.

When you start working with Fluxor, you can observe the same effect as when working with Blazor-State, so we can just continue.



At the second stage, the same actions are repeated as with Blazor-State. The data gets into our table and, accordingly, the RenderTree object grows.



After calling and transferring objects to State again, the size of the occupied memory has not changed.



It seems that at the moment the amount of memory used does not differ from what it was when working with Blazor-State. However, if you turn off Just My Code and look at the total occupied memory, you can notice significant changes.


## Blazor-State



## Fluxor



It can be noted that the Fluxor application required more memory at all stages than the same application, but only with Blazor-State.

Since we have already covered 3 of the 5 situations when working with Fluxor, let's look at the other two.


Just as before, after changing the page, some of the data is sent to the pool and some is deleted and only what is necessary is saved. But do not forget that the volume with Just My Code will be much larger.



The final step is to return to the original page. We see exactly the same data as when working with Blazor-State.



## Summary

Based on the data that we managed to collect, it follows that Blazor-State requires less memory and this is very noticeable. 

I implemented Fluxor in my project since it was the best option for pending tasks. From my point of view Fluxor has a lot of features, which makes it heavier in comparison to Blazor-State.


By Dzmitry Blotski from Igniscor

Blazor

MAUI

Hybrid

State management

Performance

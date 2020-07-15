# GleanUnity
A simple Unity program to demonstrate how to use Glean in Unity. Just open `SampleScene` from the scene folder and run it.

## How to dump logs
If there is a crash is happening. We can rely on Unity's log system. Due to our Glean native library, `glean_ffi.dll`, is written by Rust. We need to enable Rust's environment values before dumping its logs.

Insert `set RUST_BACKTRACE=1` and `set RUST_LOG=debug` in your command line tool.

After building the executable file from Unity. You can see `GleanUnity.exe` in your output folder.
Then, insert `GleanUnity.exe -batchmode -nographics -logfile mylog.txt`. You would be able to see its stacktrace from that mylog.txt.

## Check tagged pings in debug ping viewer
Glean provides a friendly debug viewer to help developers check if their pings would be uploaded to a data server successfully. As [Glean documentation](https://mozilla.github.io/glean/book/user/debugging/debug-ping-view.html) mentioned, we can easily see our results in [the debug ping viewer](https://debug-ping-preview.firebaseapp.com/) after setting an environment variable as `set GLEAN_DEBUG_VIEW_TAG=gleanpings` in your command line tool (*gleanpings* can be anything you wanna to be a name of the tag.) Then, running your executable file in the command line tool.

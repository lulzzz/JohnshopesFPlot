pushd ..\doc

REM ********** generate reflection data files for .net framework2.0****************************
msbuild fxReflection.proj /Property:NetfxVer=2.0 /Property:PresentationStyle=prototype

popd
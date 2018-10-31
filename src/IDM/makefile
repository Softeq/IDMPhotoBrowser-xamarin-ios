XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=./
PROJECT=$(PROJECT_ROOT)/IDM.xcworkspace
TARGET=IDMPhotoBrowser
OUTPUT=./Output

all: IDMPhotoBrowser.a Pop.a SDWebImage.a DACircularProgress.a

Build-i386:
	$(XBUILD) -workspace $(PROJECT) -scheme $(TARGET) -sdk iphonesimulator -derivedDataPath $(PROJECT_ROOT)/build/386 -configuration Release clean build

IDMPhotoBrowser-i386.a: Build-i386
	-mv $(PROJECT_ROOT)/build/386/Build/Products/Release-iphonesimulator/IDMPhotoBrowser/libIDMPhotoBrowser.a $@

Pop-i386.a: Build-i386
	-mv $(PROJECT_ROOT)/build/386/Build/Products/Release-iphonesimulator/pop/libpop.a $@

SDWebImage-i386.a: Build-i386
	-mv $(PROJECT_ROOT)/build/386/Build/Products/Release-iphonesimulator/SDWebImage/libSDWebImage.a $@

DACircularProgress-i386.a: Build-i386
	-mv $(PROJECT_ROOT)/build/386/Build/Products/Release-iphonesimulator/DACircularProgress/libDACircularProgress.a $@

Build-arm64:
	$(XBUILD) -workspace $(PROJECT) -scheme $(TARGET) -sdk iphoneos -derivedDataPath $(PROJECT_ROOT)/build/64 -arch arm64 -configuration Release clean build 

IDMPhotoBrowser-arm64.a: Build-arm64
	-mv $(PROJECT_ROOT)/build/64/Build/Products/Release-iphoneos/IDMPhotoBrowser/libIDMPhotoBrowser.a $@

Pop-arm64.a: Build-arm64
	-mv $(PROJECT_ROOT)/build/64/Build/Products/Release-iphoneos/pop/libpop.a $@

SDWebImage-arm64.a: Build-arm64
	-mv $(PROJECT_ROOT)/build/64/Build/Products/Release-iphoneos/SDWebImage/libSDWebImage.a $@

DACircularProgress-arm64.a: Build-arm64
	-mv $(PROJECT_ROOT)/build/64/Build/Products/Release-iphoneos/DACircularProgress/libDACircularProgress.a $@

Build-armv7:
	$(XBUILD) -workspace $(PROJECT) -scheme $(TARGET) -sdk iphoneos -derivedDataPath $(PROJECT_ROOT)/build/v7 -arch armv7 -configuration Release clean build 

IDMPhotoBrowser-armv7.a: Build-armv7
	-mv $(PROJECT_ROOT)/build/v7/Build/Products/Release-iphoneos/IDMPhotoBrowser/libIDMPhotoBrowser.a $@

Pop-armv7.a: Build-armv7
	-mv $(PROJECT_ROOT)/build/v7/Build/Products/Release-iphoneos/pop/libpop.a $@

SDWebImage-armv7.a: Build-armv7
	-mv $(PROJECT_ROOT)/build/v7/Build/Products/Release-iphoneos/SDWebImage/libSDWebImage.a $@

DACircularProgress-armv7.a: Build-armv7
	-mv $(PROJECT_ROOT)/build/v7/Build/Products/Release-iphoneos/DACircularProgress/libDACircularProgress.a $@

IDMPhotoBrowser.a: IDMPhotoBrowser-i386.a IDMPhotoBrowser-armv7.a IDMPhotoBrowser-arm64.a
	xcrun -sdk iphoneos lipo -create -output $(OUTPUT)/$@ $^
	-rm -f $^

Pop.a: Pop-i386.a Pop-armv7.a Pop-arm64.a
	xcrun -sdk iphoneos lipo -create -output $(OUTPUT)/$@ $^
	-rm -f $^

SDWebImage.a: SDWebImage-i386.a SDWebImage-armv7.a SDWebImage-arm64.a
	xcrun -sdk iphoneos lipo -create -output $(OUTPUT)/$@ $^
	-rm -f $^

DACircularProgress.a: DACircularProgress-i386.a DACircularProgress-armv7.a DACircularProgress-arm64.a
	xcrun -sdk iphoneos lipo -create -output $(OUTPUT)/$@ $^
	-rm -f $^

clean:
	-rm -f *.a *.dll $(OUTPUT)/*.a
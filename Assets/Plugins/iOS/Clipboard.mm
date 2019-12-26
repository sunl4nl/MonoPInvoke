#include "Clipboard.h"
#include "iosaddrinfo.h"
@implementation Clipboard
//将文本复制到IOS剪贴板
- (NSString*)objc_getTextFromClipboard
{
    UIPasteboard *pasteboard = [UIPasteboard generalPasteboard];
    return pasteboard.string;
}
@end

extern "C" {
    static Clipboard *iosClipboard;
    const extern char* copyStr( const char* str );
   
    const char* _getTextFromClipboard()
    {  
        if(iosClipboard == NULL)
        {
            iosClipboard = [[Clipboard alloc] init];
        }
        
        const char* clipBoardStr = [[iosClipboard objc_getTextFromClipboard] UTF8String];
       
        if(clipBoardStr != nullptr)
            return copyStr(clipBoardStr);
        else
            return copyStr("");
    }

}

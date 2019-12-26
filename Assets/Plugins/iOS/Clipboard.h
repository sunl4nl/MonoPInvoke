@ interface Clipboard : NSObject

extern "C"
{
	/*  compare the namelist with system processes  */
	const char* _getTextFromClipboard();
}

@end
